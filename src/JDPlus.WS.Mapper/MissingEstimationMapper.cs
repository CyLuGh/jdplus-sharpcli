using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class MissingEstimationMapper
{
    public static MissingEstimation ToModel(this RegArimaModelDto.Types.MissingEstimationDto dto) =>
        new(dto.Position, dto.Value, dto.Stde);
}
