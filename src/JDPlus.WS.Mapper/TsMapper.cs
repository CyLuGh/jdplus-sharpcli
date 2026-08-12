using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsMapper
{
    extension(Ts model)
    {
        public TsDto ToDto()
        {
            TsDto dto = new()
            {
                Name = model.Name,
                Moniker = model.Moniker.ToDto(),
                Data = model.Data.ToDto()
            };

            foreach ((string key, string value) in model.Metadata)
                dto.Metadata.Add(key, value);

            return dto;
        }
    }

    extension(TsDto dto)
    {
        public Ts ToModel() => new()
        {
            Name = dto.Name,
            Moniker = dto.Moniker.ToModel(),
            Data = dto.Data.ToModel(),
            Metadata = dto.Metadata.Select(x => (x.Key, x.Value)).ToHashMap()
        };
    }
}