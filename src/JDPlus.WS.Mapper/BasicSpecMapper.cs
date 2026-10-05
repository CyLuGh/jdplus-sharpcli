using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class BasicSpecMapper
{
    extension(BasicSpec model)
    {
        public BasicSpecDto ToDto() => new()
        {
            Span = model.Span.ToDto(),
            PreliminaryCheck = model.PreliminaryCheck,
            AnnualFrequency = model.AnnualFrequency
        };
    }

    extension(BasicSpecDto dto)
    {
        public BasicSpec ToModel() => new()
        {
            Span = dto.Span.ToModel(),
            PreliminaryCheck = dto.PreliminaryCheck,
            AnnualFrequency = dto.AnnualFrequency
        };
    }
}