using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ValidityPeriodMapper
{
    public static ValidityPeriod ToModel(this ValidityPeriodDto dto) =>
        new(dto.Start.ToModel(), dto.End.ToModel());

    public static ValidityPeriodDto ToDto(this ValidityPeriod model) =>
        new() { Start = model.Start.ToDto(), End = model.End.ToDto() };
}
