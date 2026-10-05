namespace JDPlus.WS.Models;

public readonly record struct BasicSpec
{
    public TimeSelector Span { get; init; }
    public bool PreliminaryCheck { get; init; }
    public int AnnualFrequency { get; init; }
}
