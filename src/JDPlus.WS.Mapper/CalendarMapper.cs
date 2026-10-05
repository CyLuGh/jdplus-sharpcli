using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class CalendarMapper
{
    public static CalendarDto ToDto(this Calendar model)
    {
        CalendarDto dto = new() { MeanCorrection = model.MeanCorrection };
        dto.FixedDays.AddRange(model.FixedDays.Select(x => x.ToDto()));
        dto.EasterRelatedDays.AddRange(model.EasterRelatedDays.Select(x => x.ToDto()));
        dto.FixedWeekDays.AddRange(model.FixedWeekDays.Select(x => x.ToDto()));
        dto.PrespecifiedHolidays.AddRange(model.PrespecifiedHolidays.Select(x => x.ToDto()));
        dto.SingleDates.AddRange(model.SingleDates.Select(x => x.ToDto()));
        return dto;
    }

    public static Calendar ToModel(this CalendarDto dto) =>
        new()
        {
            FixedDays = dto.FixedDays.Select(x => x.ToModel()).ToSeq().Strict(),
            EasterRelatedDays = dto.EasterRelatedDays.Select(x => x.ToModel()).ToSeq().Strict(),
            FixedWeekDays = dto.FixedWeekDays.Select(x => x.ToModel()).ToSeq().Strict(),
            PrespecifiedHolidays = dto
                .PrespecifiedHolidays.Select(x => x.ToModel())
                .ToSeq()
                .Strict(),
            SingleDates = dto.SingleDates.Select(x => x.ToModel()).ToSeq().Strict(),
            MeanCorrection = dto.MeanCorrection
        };
}
