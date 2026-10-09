using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using VariableType = JDPlus.WS.Models.VariableType;

namespace JDPlus.WS.Mapper;

public static class RegressionVariableMapper
{
    public static RegressionVariable ToModel(this RegressionVariableDto dto) =>
        new(
            dto.Name,
            (VariableType)dto.VarType,
            dto.Metadata.Select(x => (x.Key, x.Value)).ToHashMap(),
            dto.Coefficients.Select(x => x.ToModel()).ToSeq()
        );
}
