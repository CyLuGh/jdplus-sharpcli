using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class EstimateSpecMapper
{
    extension(EstimateSpec model)
    {
        public EstimateSpecDto ToDto() => new()
        {
            Span = model.Span.ToDto(),
            Ml = model.Ml,
            Tol = model.Tol,
            Ubp = model.Ubp
        };
    }

    extension(EstimateSpecDto dto)
    {
        public EstimateSpec ToModel() => new()
        {
            Span = dto.Span.ToModel(),
            Ml = dto.Ml,
            Tol = dto.Tol,
            Ubp = dto.Ubp
        };
    }
}