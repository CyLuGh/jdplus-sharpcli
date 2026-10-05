using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class EasterRelatedDayMapper
{
    public static EasterRelatedDay ToModel(this EasterRelatedDayDto dto) =>
        new(dto.Offset, dto.Julian, dto.Weight, dto.Validity.ToModel());

    public static EasterRelatedDayDto ToDto(this EasterRelatedDay model) =>
        new()
        {
            Offset = model.Offset,
            Julian = model.Julian,
            Weight = model.Weight,
            Validity = model.Validity.ToDto()
        };
}
