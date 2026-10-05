using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class FixedWeekDayMapper
{
    public static FixedWeekDayDto ToDto(this FixedWeekDay model) =>
        new()
        {
            Month = model.Month,
            Position = model.Position,
            Weekday = model.WeekDay,
            Weight = model.Weight,
            Validity = model.Validity.ToDto()
        };

    public static FixedWeekDay ToModel(this FixedWeekDayDto dto) =>
        new()
        {
            Month = dto.Month,
            Position = dto.Position,
            WeekDay = dto.Weekday,
            Weight = dto.Weight,
            Validity = dto.Validity.ToModel()
        };
}
