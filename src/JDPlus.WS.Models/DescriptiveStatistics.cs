namespace JDPlus.WS.Models;

public readonly record struct DescriptiveStatistics
{
    public string Id { get; init; }
    public ResultStatus Status { get; init; }
    public int N { get; init; }
    public int NMissing { get; init; }
    public double Max { get; init; }
    public double Min { get; init; }
    public double Average { get; init; }
    public double StDev { get; init; }
    public double Q25 { get; init; }
    public double Q50 { get; init; }
    public double Q75 { get; init; }
}
