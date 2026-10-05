using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TramoSpecMapper
{
    extension(TramoSpec model)
    {
        public TramoSpecDto ToDto() => new()
        {
            Basic = model.Basic.ToDto(),
            Transform = model.Transform.ToDto(),
            Outlier = model.Outlier.ToDto(),
            Arima = model.Arima.ToDto(),
            Automodel = model.AutoModel.ToDto(),
            Regression = model.Regression.ToDto(),
            Estimate = model.Estimate.ToDto()
        };
    }

    extension(TramoSpecDto dto)
    {
        public TramoSpec ToModel() => new()
        {
            Basic = dto.Basic.ToModel(),
            Transform = dto.Transform.ToModel(),
            Outlier = dto.Outlier.ToModel(),
            Arima = dto.Arima.ToModel(),
            AutoModel = dto.Automodel.ToModel(),
            Regression = dto.Regression.ToModel(),
            Estimate = dto.Estimate.ToModel()
        };
    }
}