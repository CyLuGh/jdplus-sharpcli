using System.Xml;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class LikelihoodStatisticsMapper
{
    public static LikelihoodStatistics ToModel(this LikelihoodStatisticsDto dto) =>
        new()
        {
            NObs = dto.Nobs,
            NEffectiveObs = dto.Neffectiveobs,
            NParams = dto.Nparams,
            AdjustedLogLikelihood = dto.AdjustedLogLikelihood,
            Aic = dto.Aic,
            Aicc = dto.Aicc,
            Bic = dto.Bic,
            Bic2 = dto.Bic2,
            Bicc = dto.Bicc,
            DegreesOfFreedom = dto.DegreesOfFreedom,
            HannanQuinn = dto.HannanQuinn,
            LogLikelihood = dto.LogLikelihood,
            Ssq = dto.Ssq,
        };

    public static DiffuseLikelihoodStatistics ToModel(this DiffuseLikelihoodStatisticsDto dto) =>
        new()
        {
            AdjustedLogLikelihood = dto.AdjustedLogLikelihood,
            Aic = dto.Aic,
            Aicc = dto.Aicc,
            Bic = dto.Bic,
            DCorrection = dto.Dcorrection,
            DegreesOfFreedom = dto.DegreesOfFreedom,
            LDet = dto.Ldet,
            LogLikelihood = dto.LogLikelihood,
            NDiffuse = dto.Ndiffuse,
            NObs = dto.Nobs,
            NParams = dto.Nparams,
            Ssq = dto.Ssq
        };
}
