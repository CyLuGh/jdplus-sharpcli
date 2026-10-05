using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using EasterType = JDPlus.Main.WS.V1.EasterType;

namespace JDPlus.WS.Mapper;

public static class EasterSpecMapper
{
    extension(EasterSpec model)
    {
        public EasterSpecDto ToDto() => new()
        {
            Type = (EasterType)model.Type,
            Duration = model.Duration,
            Julian = model.Julian,
            Test = model.Test,
            Coefficient = model.Coefficient.ToDto()
        };
    }

    extension(EasterSpecDto dto)
    {
        public EasterSpec ToModel() => new()
        {
            Type = (Models.EasterType)dto.Type,
            Duration = dto.Duration,
            Julian = dto.Julian,
            Test = dto.Test,
            Coefficient = dto.Coefficient.ToModel()
        };
    }
}
