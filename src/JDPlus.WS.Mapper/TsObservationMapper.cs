using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsObservationMapper
{
    extension(TsObservation model)
    {
        public TsObservationDto ToDto() => new()
        {
            Start = model.Start.ToDto(),
            End = model.End.ToDto(),
            Value = model.Value
        };
    }

    extension(TsObservationDto dto)
    {
        public TsObservation ToModel() => new()
        {
            Start = dto.Start.ToModel(),
            End = dto.End.ToModel(),
            Value = dto.Value
        };
    }
}