using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Calendar
{
    public Seq<FixedDay> FixedDays { get; init; }
    public Seq<EasterRelatedDay> EasterRelatedDays { get; init; }
    public Seq<FixedWeekDay> FixedWeekDays { get; init; }
    public Seq<PrespecifiedHoliday> PrespecifiedHolidays { get; init; }
    public Seq<SingleDate> SingleDates { get; init; }
    public bool MeanCorrection { get; init; }
}
