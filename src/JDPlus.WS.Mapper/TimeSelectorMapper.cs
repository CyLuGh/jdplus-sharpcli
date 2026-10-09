using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Mapper;

public static class TimeSelectorMapper
{
    public static TimeSelectorDto ToDto(this TimeSelector model)
    {
        var dto = new TimeSelectorDto
        {
            Type = (JDPlus.Main.WS.V1.SelectionType)model.Type,
            N0 = model.N0,
            N1 = model.N1
        };

        model.D0.IfSome(d => dto.D0 = d.ToDto());
        model.D1.IfSome(d => dto.D1 = d.ToDto());

        return dto;
    }

    public static TimeSelector ToModel(this TimeSelectorDto dto) =>
        new()
        {
            Type = (JDPlus.WS.Models.SelectionType)dto.Type,
            N0 = dto.N0,
            N1 = dto.N1,
            D0 = dto.D0?.ToModel() ?? Option<DateOnly>.None,
            D1 = dto.D1?.ToModel() ?? Option<DateOnly>.None
        };
}
