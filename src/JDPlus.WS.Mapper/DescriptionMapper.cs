using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LengthOfPeriod = JDPlus.WS.Models.LengthOfPeriod;

namespace JDPlus.WS.Mapper;

public static class DescriptionMapper
{
    public static Description ToModel(this RegArimaModelDto.Types.DescriptionDto dto) =>
        new()
        {
            Series = dto.Series.ToModel(),
            Log = dto.Log,
            Preadjustment = (LengthOfPeriod)dto.Preadjustment,
            Variables = dto.Variables.Select(x => x.ToModel()).ToSeq(),
            Arima = dto.Arima.ToModel()
        };
}
