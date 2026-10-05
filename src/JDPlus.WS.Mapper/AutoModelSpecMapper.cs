using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt.Pretty;

namespace JDPlus.WS.Mapper;

public static class AutoModelSpecMapper
{
    extension(AutoModelSpec model)
    {
        public AutoModelSpecDto ToDto() => new()
        {
            Enabled = model.Enabled,
            Cancel = model.Cancel,
            Ub1 = model.Ub1,
            Ub2 = model.Ub2,
            Pcr = model.Pcr,
            Pc= model.Pc,
            Tsig = model.Tsig,
            AcceptDef = model.AcceptDef,
            AmiCompare = model.AmiCompare
        };
    }

    extension(AutoModelSpecDto dto)
    {
        public AutoModelSpec ToModel() => new()
        {
            Enabled = dto.Enabled,
            Cancel = dto.Cancel,
            Ub1 = dto.Ub1,
            Ub2 = dto.Ub2,
            Pcr = dto.Pcr,
            Pc= dto.Pc,
            Tsig = dto.Tsig,
            AcceptDef = dto.AcceptDef,
            AmiCompare = dto.AmiCompare
        };
    }
}