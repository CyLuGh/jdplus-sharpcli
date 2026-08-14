using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TsData
{
    public static TsData Default => new() { Start = TsPeriod.Default, Values = Seq<double>.Empty };

    public required TsPeriod Start { get; init; }
    public required Seq<double> Values { get; init; }

    public HashMap<DateOnly, double> GetDateValues()
    {
        var start = Start.ToDate();
        var occurrencesPerYear = Start.MonthlyOccurrencesPerYear;

        return Values.Map((idx, v) => (start.AddMonths(idx * occurrencesPerYear), v)).ToHashMap();
    }

    public TsData MapData<T>(Func<double, T, double> mapper, T t) =>
        this with
        {
            Values = Values.Map(d => mapper(d, t))
        };
}
