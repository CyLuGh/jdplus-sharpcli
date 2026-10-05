using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class SarimaSpecMapper
{
    extension(SarimaSpec model)
    {
        public SarimaSpecDto ToDto()
        {
            var dto = new SarimaSpecDto
            {
                Period = model.Period,
                D= model.D,
                Bd = model.BD
            };
            dto.Phi.AddRange(model.Phi.ToDto());
            dto.Theta.AddRange(model.Theta.ToDto());
            dto.Bphi.AddRange(model.BPhi.ToDto());
            dto.Btheta.AddRange(model.BTheta.ToDto());

            return dto;
        }
    }

    extension(SarimaSpecDto dto)
    {
        public SarimaSpec ToModel() => new()
        {
            Period = dto.Period,
            Phi = dto.Phi.ToModel(),
            D = dto.D,
            Theta = dto.Theta.ToModel(),
            BPhi = dto.Bphi.ToModel(),
            BD = dto.Bd,
            BTheta = dto.Btheta.ToModel()
        };
    }
}