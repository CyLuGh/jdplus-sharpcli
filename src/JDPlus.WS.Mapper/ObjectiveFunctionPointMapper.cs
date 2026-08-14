using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ObjectiveFunctionPointMapper
{
    extension(ObjectiveFunctionPointDto dto)
    {
        public ObjectiveFunctionPoint ToModel()
            => new()
            {
                Value = dto.Value,
                Parameters = dto.Parameters.ToSeq(),
                Gradient = dto.Gradient.ToSeq(),
                Hessian = dto.Hessian.ToModel()
            };
    }
}