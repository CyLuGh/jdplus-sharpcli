using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using CalendarEvent = JDPlus.Main.WS.V1.CalendarEvent;

namespace JDPlus.WS.Mapper;

public static class PrespecifiedHolidayMapper
{
    public static PrespecifiedHoliday ToModel(this PrespecifiedHolidayDto dto) =>
        new((Models.CalendarEvent)dto.Event, dto.Offset, dto.Weight, dto.Validity.ToModel());

    public static PrespecifiedHolidayDto ToDto(this PrespecifiedHoliday model) =>
        new()
        {
            Event = (CalendarEvent)model.Event,
            Offset = model.Offset,
            Weight = model.Weight,
            Validity = model.Validity.ToDto()
        };
}
