using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ModellingContextMapper
{
    public static ModellingContextDto ToDto(this ModellingContext model)
    {
        ModellingContextDto dto = new();
        dto.Calendars.Add(model.Calendars.Select(x => (x.Key, x.Value.ToDto())).ToDictionary());
        dto.Variables.Add(model.Variables.Select(x => (x.Key, x.Value.ToDto())).ToDictionary());
        return dto;
    }

    public static ModellingContext ToModel(this ModellingContextDto dto) =>
        new()
        {
            Calendars = dto.Calendars.Select(x => (x.Key, x.Value.ToModel())).ToHashMap(),
            Variables = dto.Variables.Select(x => (x.Key, x.Value.ToModel())).ToHashMap(),
        };
}
