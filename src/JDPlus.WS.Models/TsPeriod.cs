namespace JDPlus.WS.Models;

public readonly record struct TsPeriod
{
    public static TsPeriod Default =>
        new()
        {
            Frequency = Frequency.Undefined,
            Position = 0,
            Year = 1900
        };

    public Frequency Frequency { get; init; }
    public int Year { get; init; }

    /// <summary>
    /// Position in the year (from 0 to Frequency excluded).
    /// </summary>
    public int Position { get; init; }

    public DateOnly ToDate() =>
        new DateOnly(Year, 1, 1).AddMonths(Position * MonthlyOccurrencesPerYear);

    public int MonthlyOccurrencesPerYear =>
        Frequency != Frequency.Undefined ? 12 / (int)Frequency : 0;
}
