using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using EasterType = JDPlus.Main.WS.V1.EasterType;

namespace JDPlus.WS.Mapper;

public static class EasterSpecMapper
{
    public static EasterSpecDto ToDto(this EasterSpec model)
    {
        var dto = new EasterSpecDto
        {
            Type = (EasterType)model.Type,
            Duration = model.Duration,
            Julian = model.Julian,
            Test = model.Test,
        };
        model.Coefficient.IfSome(coefficient => dto.Coefficient = coefficient.ToDto());

        return dto;
    }

    public static EasterSpec ToModel(this EasterSpecDto dto) =>
        new()
        {
            Type = (Models.EasterType)dto.Type,
            Duration = dto.Duration,
            Julian = dto.Julian,
            Test = dto.Test,
            Coefficient = dto.Coefficient?.ToModel() ?? Option<Parameter>.None
        };
}
