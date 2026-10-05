using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LengthOfPeriod = JDPlus.Main.WS.V1.LengthOfPeriod;
using Transformation = JDPlus.Main.WS.V1.Transformation;

namespace JDPlus.WS.Mapper;

public static class TransformSpecMapper
{
    extension(TransformSpec model)
    {
        public TransformSpecDto ToDto() => new()
        {
            Transformation = (Transformation)model.Transformation,
            Fct = model.Fct,
            Adjust = (LengthOfPeriod)model.Adjust,
            OutliersCorrection = model.OutliersCorrection
        };
    }

    extension(TransformSpecDto dto)
    {
        public TransformSpec ToModel() => new()
        {
            Transformation = (Models.Transformation)dto.Transformation,
            Fct = dto.Fct,
            Adjust = (Models.LengthOfPeriod)dto.Adjust,
            OutliersCorrection = dto.OutliersCorrection
        };
    }
}