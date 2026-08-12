using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsPeriodMapper
{
    extension(TsPeriod model)
    {
        public TsPeriodDto ToDto() => new()
        {
            Frequency = (Main.WS.V1.Frequency)model.Frequency,
            Year = model.Year,
            Pos = model.Position
        };
    }

    extension(TsPeriodDto dto)
    {
        public TsPeriod ToModel() => new()
        {
            Frequency = (Models.Frequency)dto.Frequency,
            Year = dto.Year,
            Position = dto.Pos
        };
    }
}