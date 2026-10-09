using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class RegArimaModelMapper
{
    public static RegArimaModel ToModel(this RegArimaModelDto dto) =>
        new()
        {
            Description = dto.Description.ToModel(),
            Estimation = dto.Estimation.ToModel(),
            Diagnostics = dto.Diagnostics.ToModel()
        };
}
