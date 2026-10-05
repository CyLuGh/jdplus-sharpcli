using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TimeSelectorMapper
{
    extension(TimeSelector model)
    {
        public TimeSelectorDto ToDto() => new()
        {
            Type = (JDPlus.Main.WS.V1.SelectionType)model.Type,
            N0 = model.N0,
            N1 = model.N1,
            D0 = model.D0.ToDto(),
            D1 = model.D1.ToDto()
        };
    }

    extension(TimeSelectorDto dto)
    {
        public TimeSelector ToModel() => new()
        {
            Type = (JDPlus.WS.Models.SelectionType)dto.Type,
            N0 = dto.N0,
            N1 = dto.N1,
            D0 = dto.D0.ToModel(),
            D1 = dto.D1.ToModel()
        };
    }
}