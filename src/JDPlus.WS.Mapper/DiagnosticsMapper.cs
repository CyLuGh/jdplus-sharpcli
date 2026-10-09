using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DiagnosticsMapper
{
    public static Diagnostics ToModel(this DiagnosticsDto dto) =>
        new(dto.ResidualsTests.Select(x => (x.Key, x.Value.ToModel())).ToHashMap());
}
