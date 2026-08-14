using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TemporalDisaggregationRequestMapper
{
    extension(TemporalDisaggregationRequest model)
    {
        public TemporalDisaggregationRequestDto ToDto()
        {
            TemporalDisaggregationRequestDto dto = new()
            {
                Y = model.Y.ToDto(),
                Constant = model.Constant,
                Trend = model.Trend,
                Model = model.Model,
                Average = model.Average,
                Rho = model.Rho,
                FixedRho = model.FixedRho,
                TruncatedRho = model.TruncatedRho,
                ZeroInit = model.ZeroInit,
                Algorithm = model.Algorithm,
                DiffuserEgs = model.DiffuserEgs
            };
            dto.Indicators.AddRange(model.Indicators.Map(o=>o.ToDto()));
            return dto;
        }
    }
}