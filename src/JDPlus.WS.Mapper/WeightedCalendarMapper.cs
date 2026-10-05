using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class WeightedCalendarMapper
{
    public static WeightedCalendarDto ToDto(this WeightedCalendar model)
    {
        WeightedCalendarDto dto = new();
        dto.Items.AddRange(
            model.Items.Select(x => new WeightedCalendarDto.Types.ItemDto()
            {
                Calendar = x.Calendar,
                Weight = x.Weight
            })
        );
        return dto;
    }

    public static WeightedCalendar ToModel(this WeightedCalendarDto dto) =>
        new()
        {
            Items = dto
                .Items.Select(x => new WeightedCalendar.Item()
                {
                    Calendar = x.Calendar,
                    Weight = x.Weight
                })
                .ToSeq()
                .Strict()
        };
}
