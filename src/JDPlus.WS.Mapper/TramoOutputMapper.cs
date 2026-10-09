using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class TramoOutputMapper
{
    public static TramoOutput ToModel(this TramoOutputDto dto)
    {
        var model = new TramoOutput
        {
            Result = dto.Result.ToModel(),
            EstimationSpec = dto.EstimationSpec.ToModel(),
            ResultSpec = dto.ResultSpec?.ToModel() ?? Option<TramoSpec>.None,
            Log = dto.Log?.ToModel() ?? Option<ProcessingLogs>.None
        };

        return model;
    }
}
