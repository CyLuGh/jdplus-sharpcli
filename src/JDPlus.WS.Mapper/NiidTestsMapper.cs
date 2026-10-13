using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class NiidTestsMapper
{
    extension(NiidTestsDto dto)
    {
        public NiidTests ToModel()
            => new()
            {
                Mean = dto.Mean?.ToModel() ?? Option<StatisticalTest>.None,
                Skewness = dto.Skewness?.ToModel() ?? Option<StatisticalTest>.None,
                Kurtosis = dto.Kurtosis?.ToModel() ?? Option<StatisticalTest>.None,
                DoornikHansen = dto.DoornikHansen?.ToModel() ?? Option<StatisticalTest>.None,

                LjungBox = dto.LjungBox?.ToModel() ?? Option<StatisticalTest>.None,
                BoxPierce = dto.BoxPierce?.ToModel() ?? Option<StatisticalTest>.None,
                SeasonalLjungBox = dto.SeasonalLjungBox?.ToModel() ?? Option<StatisticalTest>.None,
                SeasonalBoxPierce = dto.SeasonalBoxPierce?.ToModel() ?? Option<StatisticalTest>.None,

                RunsNumber = dto.RunsNumber?.ToModel() ?? Option<StatisticalTest>.None,
                RunsLength = dto.RunsLength?.ToModel() ?? Option<StatisticalTest>.None,
                UpDownRunsNumber = dto.UpDownRunsNumber?.ToModel() ?? Option<StatisticalTest>.None,
                UpDownRunsLength = dto.UpDownRunsLength?.ToModel() ?? Option<StatisticalTest>.None,

                LjungBoxOnSquares = dto.LjungBoxOnSquares?.ToModel() ?? Option<StatisticalTest>.None,
                BoxPierceOnSquares = dto.BoxPierceOnSquares?.ToModel() ?? Option<StatisticalTest>.None
            };
    }
}