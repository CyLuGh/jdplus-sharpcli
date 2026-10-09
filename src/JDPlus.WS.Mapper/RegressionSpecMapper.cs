using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class RegressionSpecMapper
{
    extension(RegressionSpec model)
    {
        public RegressionSpecDto ToDto()
        {
            RegressionSpecDto dto = new()
            {
                CheckMean = model.CheckMean,
                Td = model.TD.ToDto(),
                Easter = model.Easter.ToDto(),
            };
            model.Mean.IfSome(mean => dto.Mean = mean.ToDto());
            dto.Outliers.Add(model.Outliers.Map(x => x.ToDto()));
            dto.Users.Add(model.Users.Map(x => x.ToDto()));
            dto.Interventions.Add(model.Interventions.Map(x => x.ToDto()));
            dto.Ramps.Add(model.Ramps.Map(x => x.ToDto()));
            return dto;
        }
    }

    extension(RegressionSpecDto dto)
    {
        public RegressionSpec ToModel() => new()
        {
            Mean = dto.Mean?.ToModel() ?? Option<Parameter>.None,
            CheckMean = dto.CheckMean,
            TD = dto.Td.ToModel(),
            Easter = dto.Easter.ToModel(),
            Outliers = dto.Outliers.Map(x => x.ToModel()).ToSeq().Strict(),
            Users = dto.Users.Map(x => x.ToModel()).ToSeq().Strict(),
            Interventions = dto.Interventions.Map(x => x.ToModel()).ToSeq().Strict(),
            Ramps = dto.Ramps.Map(x => x.ToModel()).ToSeq().Strict(),
        };
    }
}