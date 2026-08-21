using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class TemporalDisaggregationResultsMapper
{
    extension(TemporalDisaggregationResultsDto dto)
    {
        public TemporalDisaggregationResults ToModel()
            => new()
            {
                OriginalSeries = dto.OriginalSeries.ToModel(),
                DisaggregatedSeries = dto.DisaggregatedSeries.ToModel(),
                StDevDisaggregatedSeries = dto.StDevDisaggregatedSeries.ToModel(),
                RegressionEffects = dto.RegressionEffects?.ToModel() ?? Option<TsData>.None,
                HyperParametersCount = dto.HyperParametersCount,
                Likelihood = dto.Likelihood.ToModel(),
                Statistics = dto.Stats.ToModel(),
                // TODO ResidualsDiagnostics = dto.ResidualsDiagnostics.ToModel(),
                Maximum = dto.Maximum?.ToModel() ?? Option<ObjectiveFunctionPoint>.None
            };
    }
}