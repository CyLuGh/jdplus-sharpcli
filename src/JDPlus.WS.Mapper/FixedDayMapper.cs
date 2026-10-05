using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class FixedDayMapper
{
    public static FixedDay ToModel(this FixedDayDto dto) =>
        new(dto.Month, dto.Day, dto.Weight, dto.Validity.ToModel());

    public static FixedDayDto ToDto(this FixedDay model) =>
        new()
        {
            Month = model.Month,
            Day = model.Day,
            Weight = model.Weight,
            Validity = model.Validity.ToDto()
        };
}
