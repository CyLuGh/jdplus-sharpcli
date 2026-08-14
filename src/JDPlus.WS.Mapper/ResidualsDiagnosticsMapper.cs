using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ResidualsDiagnosticsMapper
{
    extension(ResidualsDiagnosticsDto dto)
    {
        public ResidualsDiagnostics ToModel()
            => new() { FullResiduals = dto.FullResiduals.ToModel(), Niid = dto.Niid.ToModel() };
    }
}