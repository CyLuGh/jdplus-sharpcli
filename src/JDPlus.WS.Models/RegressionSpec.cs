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

public enum OutlierKind
{
    /// <summary>
    /// Additive outlier: a one-time abnormal observation affecting only a single period.
    /// </summary>
    AO,

    /// <summary>
    /// Level shift: a permanent change in the series level starting at a given date.
    /// </summary>
    LS,

    /// <summary>
    /// Transitory change: a shock that occurs suddenly and then gradually fades away.
    /// </summary>
    TC,

    /// <summary>
    /// Seasonal outlier: an abnormal observation affecting only one season (month/quarter) and compensated across the remaining seasons.
    /// </summary>
    SO
}
