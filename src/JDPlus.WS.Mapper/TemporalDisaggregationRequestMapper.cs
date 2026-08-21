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

            if (!model.Indicators.IsEmpty)
                dto.Indicators.AddRange(model.Indicators.Map(o => o.ToDto()));

            model.NBackcasts.IfSome(nb => dto.NBackcasts = nb);
            model.NForecasts.IfSome(nf => dto.NForecasts = nf);
            model.Frequency.IfSome(f => dto.Frequency = f);
            
            return dto;
        }
    }
}