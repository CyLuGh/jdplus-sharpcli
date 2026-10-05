using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class InterventionVariableMapper
{
    extension(InterventionVariable model)
    {
        public InterventionVariableDto ToDto()
        {
            var dto = new InterventionVariableDto
            {
                Name = model.Name,
                Delta = model.Delta,
                SeasonalDelta = model.SeasonalDelta,
                Coefficient = model.Coefficient.ToDto(),
            };
            dto.Sequences.AddRange(model.Sequences.Select(x => x.ToDto()));
            dto.Metadata.Add(model.MetaData.ToDictionary<string,string>());
            return dto;
        }
    }

    extension(InterventionVariableDto dto)
    {
        public InterventionVariable ToModel() => new ()
        {
            Name = dto.Name,
            Delta = dto.Delta,
            SeasonalDelta = dto.SeasonalDelta,
            Coefficient = dto.Coefficient.ToModel(),
            Sequences = dto.Sequences.Select(x => x.ToModel()).ToSeq().Strict(),
            MetaData = dto.Metadata.ToHashMap(),
        };
    }

    extension(InterventionVariable.Sequence model)
    {
        public InterventionVariableDto.Types.SequenceDto ToDto()
        {
            return new ()
            {
                Start = model.Start.ToDto(),
                End = model.End.ToDto(),
            };
        }
    }
    
    extension(InterventionVariableDto.Types.SequenceDto dto)
    {
        public InterventionVariable.Sequence ToModel()
        {
            return new()
            {
                Start = dto.Start.ToModel(),
                End = dto.End.ToModel(),
            };
        }
    }
}
