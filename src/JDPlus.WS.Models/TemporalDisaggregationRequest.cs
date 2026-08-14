using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TemporalDisaggregationRequest
{
    public TsData Y { get; init; }
    public bool Constant { get; init; }
    public bool Trend { get; init; }
    public Seq<TsData> Indicators { get; init; }
    public string Model { get; init; }
    public bool Average { get; init; }
    public double Rho { get; init; }
    public bool FixedRho { get; init; }
    public double TruncatedRho { get; init; }
    public bool ZeroInit { get; init; }
    public string Algorithm { get; init; }
    public bool DiffuserEgs { get; init; }
}
