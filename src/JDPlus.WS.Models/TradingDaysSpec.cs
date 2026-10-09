using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TradingDaysSpec
{
    public TradingDays TD { get; init; }
    public LengthOfPeriod LP { get; init; }
    public string Holidays { get; init; }
    public Seq<string> Users { get; init; }
    public int W { get; init; }
    public TradingDaysTest Test { get; init; }
    public AutomaticTradingDays Auto { get; init; }
    public double PTest { get; init; }
    public bool AutoAdjust { get; init; }
    public Seq<Parameter> TDCoefficients { get; init; }
    public Option<Parameter> LPCoefficient { get; init; }
}
