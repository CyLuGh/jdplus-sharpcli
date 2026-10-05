using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class OutlierSpecMapper
{
    extension(OutlierSpec model)
    {
        public OutlierSpecDto ToDto() => new()
        {
            Enabled = model.Enabled,
            Span = model.Span.ToDto(),
            Ao = model.Ao,
            Ls = model.Ls,
            Tc = model.Tc,
            So = model.So,
            Va = model.Va,
            Tcrate = model.Tcrate,
            Ml = model.Ml
        };
    }

    extension(OutlierSpecDto dto)
    {
        public OutlierSpec ToModel() => new()
        {
            Enabled = dto.Enabled,
            Span = dto.Span.ToModel(),
            Ao = dto.Ao,
            Ls = dto.Ls,
            Tc = dto.Tc,
            So = dto.So,
            Va = dto.Va,
            Tcrate = dto.Tcrate,
            Ml = dto.Ml
        };
    }
}