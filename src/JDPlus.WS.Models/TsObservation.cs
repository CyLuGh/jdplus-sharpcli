using System.Diagnostics.CodeAnalysis;

namespace JDPlus.WS.Models;

/// <summary>
/// Observation defined on a calendar period
/// </summary>
public readonly record struct TsObservation
{
    /// <summary>
    /// For point observations, start should be equal to end. Otherwise, start is included in the period corresponding to the observation.
    /// </summary>
    public required DateOnly Start { get; init; }

    /// <summary>
    /// For point observations, start should be equal to end. Otherwise, end is excluded from the period corresponding to the observation.
    /// </summary>
    public required DateOnly End { get; init; }
    public required double Value { get; init; }

    [SetsRequiredMembers]
    public TsObservation(DateOnly date, double value)
        : this(date, date, value) { }

    [SetsRequiredMembers]
    public TsObservation(DateOnly start, DateOnly end, double value)
    {
        Start = start;
        End = end;
        Value = value;
    }
}
