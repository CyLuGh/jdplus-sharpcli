using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class OutlierMapper
{
    extension(Outlier model)
    {
        public OutlierDto ToDto()
        {
            var dto = new OutlierDto
            {
                Name = model.Name,
                Code = model.Code,
                Position = model.Position.ToDto(),
                Coefficient = model.Coefficient.ToDto()
            };
            dto.Metadata.Add(model.MetaData.ToDictionary<string,string>());
            return dto;
        }
    }

    extension(OutlierDto dto)
    {
        public Outlier ToModel() => new()
        {
            Name = dto.Name,
            Code = dto.Code,
            Position = dto.Position.ToModel(),
            Coefficient = dto.Coefficient.ToModel(),
            MetaData = dto.Metadata.ToHashMap<string,string>()
        };
    }
}
