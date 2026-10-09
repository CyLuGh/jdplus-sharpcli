using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class ParametersEstimationMapper
{
    public static ParametersEstimation ToModel(this ParametersEstimationDto dto) =>
        new(
            dto.Value.ToSeq(),
            dto.Score.ToSeq(),
            dto.Covariance.ToModel(),
            dto.HasDescription ? dto.Description : Option<string>.None
        );
}
