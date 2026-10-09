using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class BasicSpecMapper
{
    public static BasicSpecDto ToDto(this BasicSpec model) =>
        new()
        {
            Span = model.Span.ToDto(),
            PreliminaryCheck = model.PreliminaryCheck,
            AnnualFrequency = model.AnnualFrequency
        };

    public static BasicSpec ToModel(this BasicSpecDto dto) =>
        new()
        {
            Span = dto.Span.ToModel(),
            PreliminaryCheck = dto.PreliminaryCheck,
            AnnualFrequency = dto.AnnualFrequency
        };
}
