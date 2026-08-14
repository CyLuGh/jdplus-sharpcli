namespace JDPlus.WS.Models;

public readonly record struct TsDomain
{
    public TsPeriod StartPeriod { get; init; }
    public int Length { get; init; }
}
