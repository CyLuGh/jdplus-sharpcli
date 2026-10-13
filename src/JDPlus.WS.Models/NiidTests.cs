using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct NiidTests
{
    public Option<StatisticalTest> Mean { get; init; }
    public Option<StatisticalTest> Skewness { get; init; }
    public Option<StatisticalTest> Kurtosis { get; init; }
    public Option<StatisticalTest> DoornikHansen { get; init; }

    public Option<StatisticalTest> LjungBox { get; init; }
    public Option<StatisticalTest> BoxPierce { get; init; }
    public Option<StatisticalTest> SeasonalLjungBox { get; init; }
    public Option<StatisticalTest> SeasonalBoxPierce { get; init; }

    public Option<StatisticalTest> RunsNumber { get; init; }
    public Option<StatisticalTest> RunsLength { get; init; }
    public Option<StatisticalTest> UpDownRunsNumber { get; init; }
    public Option<StatisticalTest> UpDownRunsLength { get; init; }

    public Option<StatisticalTest> LjungBoxOnSquares { get; init; }
    public Option<StatisticalTest> BoxPierceOnSquares { get; init; }
}
