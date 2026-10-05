using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using ParameterType = JDPlus.Main.WS.V1.ParameterType;

namespace JDPlus.WS.Mapper;

public static class ParameterMapper
{
    extension(Parameter model)
    {
        public ParameterDto ToDto() => new()
        {
            Value = model.Value,
            Type = (ParameterType)model.Type,
            Description = model.Description,
        };
    }
    
    extension(ParameterDto dto)
    {
        public Parameter ToModel() => new()
        {
            Value = dto.Value,
            Type = (Models.ParameterType)dto.Type,
            Description = dto.Description,
        };
    }
    
    extension(Seq<Parameter> model)
    {
        public Seq<ParameterDto> ToDto() => model.Map(x => x.ToDto());
    }

    extension(IEnumerable<ParameterDto> dto)
    {
        public Seq<Parameter> ToModel() => dto.Map(x => x.ToModel()).ToSeq().Strict();
    }
}
