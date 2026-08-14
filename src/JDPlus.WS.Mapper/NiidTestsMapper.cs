using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class NiidTestsMapper
{
    extension(NiidTestsDto dto)
    {
        public NiidTests ToModel()
            => new()
            {
                Mean = dto.Mean.ToModel(),
                Skewness = dto.Skewness.ToModel(),
                Kurtosis = dto.Kurtosis.ToModel(),
                DoornikHansen = dto.DoornikHansen.ToModel(),

                LjungBox = dto.LjungBox.ToModel(),
                BoxPierce = dto.BoxPierce.ToModel(),
                SeasonalLjungBox = dto.SeasonalLjungBox.ToModel(),
                SeasonalBoxPierce = dto.SeasonalBoxPierce.ToModel(),

                RunsNumber = dto.RunsNumber.ToModel(),
                RunsLength = dto.RunsLength.ToModel(),
                UpDownRunsNumber = dto.UpDownRunsNumber.ToModel(),
                UpDownRunsLength = dto.UpDownRunsLength.ToModel(),

                LjungBoxOnSquares = dto.LjungBoxOnSquares.ToModel(),
                BoxPierceOnSquares = dto.BoxPierceOnSquares.ToModel()
            };
    }
}