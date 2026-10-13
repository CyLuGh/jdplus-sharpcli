using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsDomainMapper
{
    public static TsDomain ToModel(this TsDomainDto dto) =>
        new(dto.StartPeriod.ToModel(), dto.Length);
}
