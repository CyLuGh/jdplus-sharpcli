using System;
using System.Collections.Generic;
using System.Text;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

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
                RegressionEffects = dto.RegressionEffects.ToModel()
            };
    }
}