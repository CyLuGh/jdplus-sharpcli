using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ChainedCalendarMapper
{
    public static ChainedCalendarDto ToDto(this ChainedCalendar model) =>
        new()
        {
            Calendar1 = model.Calendar1,
            Calendar2 = model.Calendar2,
            BreakDate = model.BreakDate.ToDto()
        };

    public static ChainedCalendar ToModel(this ChainedCalendarDto dto) =>
        new()
        {
            Calendar1 = dto.Calendar1,
            Calendar2 = dto.Calendar2,
            BreakDate = dto.BreakDate.ToModel()
        };
}
