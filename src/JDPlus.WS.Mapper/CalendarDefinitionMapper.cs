using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class CalendarDefinitionMapper
{
    public static CalendarDefinitionDto ToDto(this CalendarDefinition model) =>
        model switch
        {
            Calendar calendar => new CalendarDefinitionDto { Calendar = calendar.ToDto() },
            WeightedCalendar weightedCal
                => new CalendarDefinitionDto { WeightedCalendar = weightedCal.ToDto() },
            ChainedCalendar chainedCal
                => new CalendarDefinitionDto { ChainedCalendar = chainedCal.ToDto() }
        };

    public static CalendarDefinition ToModel(this CalendarDefinitionDto dto) =>
        dto.DefinitionCase switch
        {
            CalendarDefinitionDto.DefinitionOneofCase.Calendar
                => new CalendarDefinition(dto.Calendar.ToModel()),
            CalendarDefinitionDto.DefinitionOneofCase.WeightedCalendar
                => new CalendarDefinition(dto.WeightedCalendar.ToModel()),
            CalendarDefinitionDto.DefinitionOneofCase.ChainedCalendar
                => new CalendarDefinition(dto.ChainedCalendar.ToModel()),
            _ => throw new ArgumentException("Invalid definition case")
        };
}
