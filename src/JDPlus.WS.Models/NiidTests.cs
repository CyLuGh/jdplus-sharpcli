namespace JDPlus.WS.Models;

public readonly record struct NiidTests
{
    public StatisticalTest Mean { get; init; }
    public StatisticalTest Skewness { get; init; }
    public StatisticalTest Kurtosis { get; init; }
    public StatisticalTest DoornikHansen { get; init; }

    public StatisticalTest LjungBox { get; init; }
    public StatisticalTest BoxPierce { get; init; }
    public StatisticalTest SeasonalLjungBox { get; init; }
    public StatisticalTest SeasonalBoxPierce { get; init; }

    public StatisticalTest RunsNumber { get; init; }
    public StatisticalTest RunsLength { get; init; }
    public StatisticalTest UpDownRunsNumber { get; init; }
    public StatisticalTest UpDownRunsLength { get; init; }

    public StatisticalTest LjungBoxOnSquares { get; init; }
    public StatisticalTest BoxPierceOnSquares { get; init; }
}
