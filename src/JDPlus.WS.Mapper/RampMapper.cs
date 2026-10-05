using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class RampMapper
{
    extension(Ramp model)
    {
        public RampDto ToDto()
        {
            var dto = new RampDto
            {
                Name = model.Name,
                Start = model.Start.ToDto(),
                End = model.End.ToDto(),
                Coefficient = model.Coefficient.ToDto(),
            };
            dto.Metadata.Add(model.MetaData.ToDictionary<string,string>());
            return dto;
        }
    }

    extension(RampDto dto)
    {
        public Ramp ToModel() => new()
        {
            Name = dto.Name,
            Start = dto.Start.ToModel(),
            End = dto.End.ToModel(),
            Coefficient = dto.Coefficient.ToModel(),
            MetaData = dto.Metadata.ToHashMap(),
        };
    }
}
