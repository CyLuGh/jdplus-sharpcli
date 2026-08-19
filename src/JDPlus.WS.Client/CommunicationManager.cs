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
    private Option<X509Certificate2> _certificate;

    private TsFunctions.TsFunctionsClient GetClient()
    {
        var handler = new HttpClientHandler();
        var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(10) };
        var channelOptions = new GrpcChannelOptions
        {
            HttpClient = httpClient,
            MaxReceiveMessageSize = 1024 * 1024 * 200,
            MaxSendMessageSize = 1024 * 1024 * 200,
        };
        var url = "http://localhost:4566";
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
            : throw new InvalidOperationException("Error building time series data");
    }

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
}
