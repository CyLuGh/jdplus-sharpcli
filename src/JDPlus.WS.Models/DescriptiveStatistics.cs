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

    public override string ToString() =>
        $"""
            Status: {Status.Type}
            N: {N}
            NMissing: {NMissing}
            Max: {Max}
            Min: {Min}
            Average: {Average:N4}
            StDev: {StDev:N4}
            Q25: {Q25:N4}
            Q50: {Q50:N4}
            Q75: {Q75:N4}
            """;
}
