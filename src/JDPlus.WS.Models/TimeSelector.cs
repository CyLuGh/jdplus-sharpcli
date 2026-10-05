namespace JDPlus.WS.Models;

public readonly record struct TimeSelector
{
    public SelectionType Type { get; init; }
    public int N0 { get; init; }
    public int N1 { get; init; }
    public DateOnly D0 { get; init; }
    public DateOnly D1 { get; init; }
}
