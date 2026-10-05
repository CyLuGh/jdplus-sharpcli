using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class SingleDateMapper
{
    public static SingleDateDto ToDto(this SingleDate model) =>
        new() { Date = model.Date.ToDto(), Weight = model.Weight };

    public static SingleDate ToModel(this SingleDateDto dto) => new(dto.Date.ToModel(), dto.Weight);
}
