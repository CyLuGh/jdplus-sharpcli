using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class EstimationMapper
{
    public static Estimation ToModel(this RegArimaModelDto.Types.EstimationDto dto) =>
        new()
        {
            Y = dto.Y.ToSeq(),
            X = dto.X.ToModel(),
            B = dto.B.ToSeq(),
            BCovariance = dto.Bcovariance.ToModel(),
            Parameters = dto.Parameters.ToModel(),
            Likelihood = dto.Likelihood.ToModel(),
            Residuals = dto.Residuals.ToSeq(),
            Missings = dto.Missings.Select(x => x.ToModel()).ToSeq()
        };
}
