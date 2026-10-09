using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct RegressionSpec
{
    public Option<Parameter> Mean { get; init; }
    public bool CheckMean { get; init; }
    public TradingDaysSpec TD { get; init; }
    public EasterSpec Easter { get; init; }
    public Seq<Outlier> Outliers { get; init; }
    public Seq<TsVariable> Users { get; init; }
    public Seq<InterventionVariable> Interventions { get; init; }
    public Seq<Ramp> Ramps { get; init; }
}
