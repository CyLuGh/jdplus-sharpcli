namespace JDPlus.WS.Models;

public readonly record struct OutlierSpec
{
    public bool Enabled { get; init; }
    public TimeSelector Span { get; init; }
    public bool Ao { get; init; }
    public bool Ls { get; init; }
    public bool Tc { get; init; }
    public bool So { get; init; }
    public double Va { get; init; }
    public double Tcrate { get; init; }
    public bool Ml { get; init; }
}
