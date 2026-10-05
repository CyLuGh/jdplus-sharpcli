using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class CalendarDefinitionMapper
{
    public static CalendarDefinitionDto ToDto(this CalendarDefinition model) =>
        model.Definition.Match(
            calendar => new CalendarDefinitionDto { Calendar = calendar.ToDto() },
            weightedCal => new CalendarDefinitionDto { WeightedCalendar = weightedCal.ToDto() },
            chainedCal => new CalendarDefinitionDto { ChainedCalendar = chainedCal.ToDto() }
        );

    public static CalendarDefinition ToModel(this CalendarDefinitionDto dto) =>
        dto.DefinitionCase switch
        {
            CalendarDefinitionDto.DefinitionOneofCase.Calendar
                => new CalendarDefinition { Definition = dto.Calendar.ToModel() },
            CalendarDefinitionDto.DefinitionOneofCase.WeightedCalendar
                => new CalendarDefinition { Definition = dto.WeightedCalendar.ToModel() },
            CalendarDefinitionDto.DefinitionOneofCase.ChainedCalendar
                => new CalendarDefinition { Definition = dto.ChainedCalendar.ToModel() },
            _ => throw new ArgumentException("Invalid definition case")
        };
}
