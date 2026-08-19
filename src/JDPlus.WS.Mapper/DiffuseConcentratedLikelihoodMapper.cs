using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DiffuseConcentratedLikelihoodMapper
{
    extension(DiffuseConcentratedLikelihoodDto dto)
    {
        public DiffuseConcentratedLikelihood ToModel()
            => new()
            {
                B = dto.B.ToSeq(),
                Bvar = dto.Bvar?.ToModel()?? new (), // Shouldn't be null...
                LdDet = dto.Lddet,
                LDet = dto.Ldet,
                Legacy = dto.Legacy,
                Ll = dto.Ll,
                Nd = dto.Nd,
                NObs = dto.Nobs,
                Nxd = dto.Nxd,
                ScalingFactor = dto.ScalingFactor,
                Res = dto.Res.ToSeq(),
                SsqErr = dto.Ssqerr
            };
    }
}