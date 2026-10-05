namespace JDPlus.WS.Models;

public readonly record struct FixedWeekDay
{
    public int Month { get; init; }

    /// <summary>
    /// Corresponds to the first, second...)
    /// </summary>
    public int Position { get; init; }

    /// <summary>
    /// ISO-8601 standard, from 1 (Monday) to 7 (Sunday)
    /// </summary>
    public int WeekDay { get; init; }
    public double Weight { get; init; }

    public ValidityPeriod Validity { get; init; }
}
