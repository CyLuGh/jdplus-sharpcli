using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class TsVariableMapper
{
    public static TsVariableDto ToDto(this TsVariable model)
    {
        var dto = new TsVariableDto
        {
            Name = model.Name,
            Id = model.Id,
            Lag = model.Lag,
            Coefficient = model.Coefficient.ToDto(),
        };
        dto.Metadata.Add(model.MetaData.ToDictionary<string, string>());

        return dto;
    }

    public static TsVariable ToModel(this TsVariableDto dto) =>
        new()
        {
            Name = dto.Name,
            Id = dto.Id,
            Lag = dto.Lag,
            Coefficient = dto.Coefficient.ToModel(),
            MetaData = dto.Metadata.ToHashMap()
        };

    public static Seq<TsVariable> ToModel(this IEnumerable<TsVariableDto> dtos) =>
        dtos.Map(x => x.ToModel()).ToSeq().Strict();
}
