using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DynamicTsDataMapper
{
    public static DynamicTsDataDto ToDto(this DynamicTsData model) =>
        new() { Moniker = model.Moniker.ToDto(), Current = model.Current.ToDto() };

    public static DynamicTsData ToModel(this DynamicTsDataDto dto) =>
        new() { Moniker = dto.Moniker.ToModel(), Current = dto.Current.ToModel() };
}
