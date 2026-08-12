using JDPlus.Main.WS.V1;

namespace JDPlus.WS.Mapper;

public static class DateMapper
{
    extension(DateOnly date)
    {
        public DateDto ToDto() => new()
        {
            Year = date.Year,
            Month = date.Month,
            Day = date.Day
        };
    }

    extension(DateDto dto)
    {
        public DateOnly ToModel() => new(dto.Year, dto.Month, dto.Day);
    }
}