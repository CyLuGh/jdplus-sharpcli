using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using LanguageExt.Common;

namespace JDPlus.WS.Mapper;

public static class TemporalDisaggregationResultsMapper
{
    public static Option<TemporalDisaggregationResults> ToModel(
        this TemporalDisaggregationResponseDto dto
    ) =>
        dto.ResultCase switch
        {
            TemporalDisaggregationResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
            _ => Option<TemporalDisaggregationResults>.None,
        };

    public static Either<Error, TemporalDisaggregationResults> ToResult(
        this TemporalDisaggregationResponseDto dto
    ) =>
        dto.ResultCase switch
        {
            TemporalDisaggregationResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
            TemporalDisaggregationResponseDto.ResultOneofCase.Err => Error.New(dto.Err.Message),
            _ => throw new ArgumentOutOfRangeException(),
        };

    public static TemporalDisaggregationResults ToModel(
        this TemporalDisaggregationResultsDto dto
    ) =>
        new()
        {
            OriginalSeries = dto.OriginalSeries.ToModel(),
            DisaggregationDomain = dto.DisaggregationDomain.ToModel(),
            Indicators = dto.Indicators.ToModel(),
            DisaggregatedSeries = dto.DisaggregatedSeries.ToModel(),
            StDevDisaggregatedSeries = dto.StDevDisaggregatedSeries.ToModel(),
            RegressionEffects = dto.RegressionEffects?.ToModel() ?? Option<TsData>.None,
            HyperParametersCount = dto.HyperParametersCount,
            Likelihood = dto.Likelihood.ToModel(),
            Statistics = dto.Stats.ToModel(),
            ResidualsDiagnostics = dto.ResidualsDiagnostics.ToModel(),
            Maximum = dto.Maximum?.ToModel() ?? Option<ObjectiveFunctionPoint>.None,
        };
}
