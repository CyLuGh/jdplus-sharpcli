using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using InformationType = JDPlus.WS.Models.InformationType;

namespace JDPlus.WS.Mapper;

public static class ProcessingInformationMapper
{
    public static ProcessingInformation ToModel(this ProcessingInformationDto dto) =>
        new()
        {
            Name = dto.Name,
            Origin = dto.Origin,
            Message = dto.Msg,
            Type = (InformationType)dto.Type,
            Details = dto.Details.ToModel()
        };
}
