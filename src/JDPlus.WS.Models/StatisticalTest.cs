namespace JDPlus.WS.Models;

public readonly record struct StatisticalTest
{
    public double Value { get; init; }
    public double PValue { get; init; }
    public string Description { get; init; }
}
