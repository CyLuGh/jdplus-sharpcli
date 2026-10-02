using System.Security.Cryptography.X509Certificates;
using Grpc.Net.Client;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using LanguageExt;
using AggregationType = JDPlus.WS.Models.AggregationType;
using Frequency = JDPlus.WS.Models.Frequency;
using ResultStatusType = JDPlus.Main.WS.V1.ResultStatusType;

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

    public async Task<DescriptiveStatistics> GetDescriptiveStatistics(
        TsData data,
        CancellationToken token = default
    )
    {
        var input = new TsFunctionInputDto { Id = string.Empty, Series = data.ToDto() };
        var dto = await GetClient()
            .StatisticsAsync(input, cancellationToken: token)
            .ConfigureAwait(false);
        return dto.ToModel();
    }

    public async Task<TsData> BuildTsData(
        Seq<(DateOnly Date, double Value)> data,
        AggregationType aggregationType = AggregationType.None,
        Frequency frequency = Frequency.Yearly,
        bool allowPartialAggregation = true,
        bool includeMissingValues = true,
        CancellationToken token = default
    )
    {
        var input = new BuildTsDataInputDto()
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

        return dto.Status.Type == ResultStatusType.StatusOk
            ? dto.Series.ToModel()
            : throw new InvalidOperationException(
                $"Error building time series data: {dto.Status.Message}"
            );
    }

    public Task<TemporalDisaggregationResults> ProcessTemporalDisaggregation(
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
                NForecasts = nForecasts ?? Option<int>.None
            },
            token
        );

    public async Task<TemporalDisaggregationResults> ProcessTemporalDisaggregation(
        TemporalDisaggregationRequest request,
        CancellationToken token = default
    )
    {
        var req = request.ToDto();
        var res = await GetClient()
            .ProcessTemporalDisaggregationAsync(req, cancellationToken: token)
            .ConfigureAwait(false);
        return res.ToModel();
    }

    public async Task<TramoForecasts> GetTramoForecasts(
        TsData series,
        string defSpec,
        int nForecasts,
        CancellationToken token = default
    )
    {
        var results = await GetClient()
            .TramoForecastAsync(
                new TramoForecastRequestDto()
                {
                    Series = series.ToDto(),
                    DefSpec = defSpec,
                    NForecasts = nForecasts
                },
                cancellationToken: token
            )
            .ConfigureAwait(false);

        var matrix = results.ToModel();

        List<TramoForecast> tfs = [];
        for (int i = 0; i < matrix.Values.Length; i += 4)
        {
            tfs.Add(
                new TramoForecast(
                    matrix.Values[i],
                    matrix.Values[i + 1],
                    matrix.Values[i + 2],
                    matrix.Values[i + 3]
                )
            );
        }

        return new TramoForecasts(series.End, series.MonthlyOccurrencesPerYear, tfs);
    }
}
