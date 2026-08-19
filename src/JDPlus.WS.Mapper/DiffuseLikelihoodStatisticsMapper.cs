using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DiffuseLikelihoodStatisticsMapper
{
    extension(DiffuseLikelihoodStatisticsDto dto)
    {
        public DiffuseLikelihoodStatistics ToModel()
            => new()
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
}