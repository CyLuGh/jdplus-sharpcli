using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsVariableMapper
{
    extension(TsVariable model)
    {
        public TsVariableDto ToDto()
        {
            var dto = new TsVariableDto
            {
                Name = model.Name,
                Id = model.Id,
                Lag = model.Lag,
                Coefficient = model.Coefficient.ToDto(),
            };
            dto.Metadata.Add(model.MetaData.ToDictionary<string,string>());
            
            return dto;
        }
    }

    extension(TsVariableDto dto)
    {
        public TsVariable ToModel() => new ()
        {
            Name = dto.Name,
            Id = dto.Id,
            Lag = dto.Lag,
            Coefficient = dto.Coefficient.ToModel(),
            MetaData = dto.Metadata.ToHashMap()
        };
    }
}
