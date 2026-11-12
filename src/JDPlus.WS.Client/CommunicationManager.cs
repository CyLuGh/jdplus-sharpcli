using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Grpc.Core;
using Grpc.Net.Client;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using LanguageExt;
using LanguageExt.Common;
using AggregationType = JDPlus.WS.Models.AggregationType;
using Frequency = JDPlus.WS.Models.Frequency;
using VersionInfo = JDPlus.WS.Models.VersionInfo;

namespace JDPlus.WS.Client;

public class CommunicationManager
{
    private readonly Option<X509Certificate2> _certificate;
    private readonly Option<string> _url;

    public CommunicationManager() { }

    public CommunicationManager(string url)
    {
        _url = url;
    }

    public CommunicationManager(string url, string certificatePath)
        : this(url)
    {
        try
        {
            _certificate = X509CertificateLoader.LoadCertificate(
                File.ReadAllBytes(certificatePath)
            );
        }
        catch (Exception)
        {
            _certificate = Option<X509Certificate2>.None;
        }
    }

    private TsFunctions.TsFunctionsClient GetClient()
    {
        var handler = new HttpClientHandler();
        _certificate.IfSome(cert => handler.ClientCertificates.Add(cert));

        var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(10) };
        var channelOptions = new GrpcChannelOptions
        {
            HttpClient = httpClient,
            MaxReceiveMessageSize = 1024 * 1024 * 200,
            MaxSendMessageSize = 1024 * 1024 * 200,
        };

        var url = _url.Match(u => u, () => "http://localhost:4566");
        var channel = GrpcChannel.ForAddress(url, channelOptions);
        return new TsFunctions.TsFunctionsClient(channel);
    }

    public async Task<VersionInfo> GetVersion(CancellationToken token = default)
    {
        var dto = await GetClient()
            .GetVersionAsync(new(), cancellationToken: token)
            .ConfigureAwait(false);
        return dto.ToModel();
    }

    public async Task<Either<Error, DescriptiveStatistics>> GetDescriptiveStatistics(
        TsData data,
        CancellationToken token = default
    )
    {
        var input = new TsFunctionRequestDto { Id = string.Empty, Series = data.ToDto() };
        var dto = await GetClient()
            .StatisticsAsync(input, cancellationToken: token)
            .ConfigureAwait(false);
        return dto.ToResult();
    }

    public async Task<Either<Error, TsData>> BuildTsData(
        Seq<(DateOnly Date, double Value)> data,
        AggregationType aggregationType = AggregationType.None,
        Frequency frequency = Frequency.Yearly,
        bool allowPartialAggregation = true,
        bool includeMissingValues = true,
        CancellationToken token = default
    )
    {
        try
        {
            var input = new BuildTsDataRequestDto()
            {
                Gathering = new ObsGatheringDto()
                {
                    AggregationType = (Main.WS.V1.AggregationType)aggregationType,
                    AllowPartialAggregation = allowPartialAggregation,
                    Frequency = (Main.WS.V1.Frequency)frequency,
                    IncludeMissingValues = includeMissingValues,
                },
                Id = string.Empty,
            };
            input.Observations.AddRange(
                data.Map(t => new BuildTsDataObsDto() { Date = t.Date.ToDto(), Value = t.Value })
            );

            var dto = await GetClient()
                .BuildTsDataAsync(input, cancellationToken: token)
                .ConfigureAwait(false);

            return dto.ResultCase switch
            {
                BuildTsDataResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
                BuildTsDataResponseDto.ResultOneofCase.Err => Error.New(dto.Err.Message),
                _ => Error.New("Unknown result case"),
            };
        }
        catch (Exception exc)
        {
            return Error.New(exc);
        }
    }

    public Task<Either<Error, TemporalDisaggregationResults>> ProcessTemporalDisaggregation(
        TsData y,
        bool constant = false,
        bool trend = false,
        string model = "",
        bool average = false,
        double rho = 0d,
        bool fixedRho = false,
        double truncatedRho = 0d,
        bool zeroInit = false,
        string algorithm = "",
        bool diffuserEgs = false,
        int? freq = null,
        int? nBackcasts = null,
        int? nForecasts = null,
        CancellationToken token = default
    ) =>
        ProcessTemporalDisaggregation(
            new TemporalDisaggregationRequest()
            {
                Y = y,
                Constant = constant,
                Trend = trend,
                Model = model,
                Average = average,
                Rho = rho,
                FixedRho = fixedRho,
                TruncatedRho = truncatedRho,
                ZeroInit = zeroInit,
                Algorithm = algorithm,
                DiffuserEgs = diffuserEgs,
                Frequency = freq ?? Option<int>.None,
                NBackcasts = nBackcasts ?? Option<int>.None,
                NForecasts = nForecasts ?? Option<int>.None,
            },
            token
        );

    public async Task<Either<Error, TemporalDisaggregationResults>> ProcessTemporalDisaggregation(
        TemporalDisaggregationRequest request,
        CancellationToken token = default
    )
    {
        var req = request.ToDto();
        var res = await GetClient()
            .ProcessTemporalDisaggregationAsync(req, cancellationToken: token)
            .ConfigureAwait(false);
        return res.ToResult();
    }

    public static TramoRequestDto BuildTramoRequest(
        TsData series,
        Either<string, TramoSpec> spec,
        int nForecasts,
        Option<ModellingContext> context
    )
    {
        var request = spec.Match(
            fullSpec => new TramoRequestDto
            {
                Series = series.ToDto(),
                FullSpec = fullSpec.ToDto(),
                NForecasts = nForecasts,
            },
            defSpec => new TramoRequestDto
            {
                Series = series.ToDto(),
                DefSpec = defSpec,
                NForecasts = nForecasts,
            }
        );
        context.IfSome(mc => request.ModellingContext = mc.ToDto());
        request.Id = Guid.CreateVersion7().ToString();
        return request;
    }

    public async Task<Either<Error, TramoForecasts>> GetTramoForecasts(
        TsData series,
        Either<string, TramoSpec> spec,
        int nForecasts,
        Option<ModellingContext> context,
        CancellationToken token = default
    )
    {
        var request = BuildTramoRequest(series, spec, nForecasts, context);
        var response = await GetClient()
            .TramoForecastAsync(request, cancellationToken: token)
            .ConfigureAwait(false);

        var result = response.ToResult();
        return result.Map(r => new TramoForecasts(r));
    }

    public async IAsyncEnumerable<(
        string Id,
        Either<Error, TramoForecasts> Forecasts
    )> GetTramoForecasts(
        Seq<TramoRequestDto> requestDtos,
        [EnumeratorCancellation] CancellationToken token = default
    )
    {
        using var stream = GetClient().TramoForecastStream(cancellationToken: token);

        var writer = WriteTramoRequests(stream.RequestStream, requestDtos, token);

        while (await stream.ResponseStream.MoveNext(token))
        {
            yield return (
                stream.ResponseStream.Current.Id,
                stream.ResponseStream.Current.ToResult().Map(r => new TramoForecasts(r))
            );
        }

        await writer;
    }

    private static async Task WriteTramoRequests(
        IClientStreamWriter<TramoRequestDto> requestStream,
        Seq<TramoRequestDto> requests,
        CancellationToken token
    )
    {
        foreach (var request in requests)
        {
            token.ThrowIfCancellationRequested();
            await requestStream.WriteAsync(request, token);
        }

        await requestStream.CompleteAsync();
    }

    public async Task<Either<Error, TramoOutput>> GetTramoFullProcess(
        TsData series,
        Either<string, TramoSpec> spec,
        Option<ModellingContext> context,
        CancellationToken token = default
    )
    {
        try
        {
            var request = BuildTramoRequest(series, spec, 0, context);
            var results = await GetClient()
                .TramoFullProcessAsync(request, cancellationToken: token)
                .ConfigureAwait(false);

            return results.ResultCase switch
            {
                TramoFullProcessResponseDto.ResultOneofCase.Ok => results.Ok.ToModel(),
                TramoFullProcessResponseDto.ResultOneofCase.Err => Error.New(results.Err.Message),
                _ => Error.New("Unknown result case"),
            };
        }
        catch (Exception exc)
        {
            return Error.New(exc);
        }
    }
}
