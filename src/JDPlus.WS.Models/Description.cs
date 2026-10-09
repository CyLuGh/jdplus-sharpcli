using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Description
{
    public TsData Series { get; init; }
    public bool Log { get; init; }
    public LengthOfPeriod Preadjustment { get; init; }
    public Seq<RegressionVariable> Variables { get; init; }
    public SarimaSpec Arima { get; init; }
}
