using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ProcessingLogsMapper
{
    public static ProcessingLogs ToModel(this ProcessingLogsDto dto) =>
        new(dto.Log.Select(x => x.ToModel()).ToSeq());
}
