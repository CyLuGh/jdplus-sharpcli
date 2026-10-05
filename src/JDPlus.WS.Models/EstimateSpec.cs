namespace JDPlus.WS.Models;

public readonly record struct EstimateSpec
{
    public TimeSelector Span { get; init; }
    public bool Ml { get; init; }
    public double Tol { get; init; }
    public double Ubp { get; init; }
}
