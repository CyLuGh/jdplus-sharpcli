using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using ResultStatusType = JDPlus.WS.Models.ResultStatusType;

namespace JDPlus.WS.Mapper;

public static class ResultStatusMapper
{
    extension(ResultStatus model)
    {
        public ResultStatusDto ToDto() => new()
        {
            Message = model.Message,
            Type = (JDPlus.Main.WS.V1.ResultStatusType)model.Type
        };
    }

    extension(ResultStatusDto dto)
    {
        public ResultStatus ToModel() => new()
        {
            Message = dto.Message, 
            Type = (ResultStatusType)dto.Type
        };
    }
}