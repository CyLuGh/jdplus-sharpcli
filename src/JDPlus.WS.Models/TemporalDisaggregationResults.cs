using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TemporalDisaggregationResults
{
    public TsData OriginalSeries { get; init; }
    public TsDomain DisaggregationDomain { get; init; }
    public Seq<TsVariable> Indicators { get; init; }
    public int HyperParametersCount { get; init; }
    public DiffuseConcentratedLikelihood Likelihood { get; init; }
    public DiffuseLikelihoodStatistics Statistics { get; init; }
    public Option<ObjectiveFunctionPoint> Maximum { get; init; }
    public ResidualsDiagnostics ResidualsDiagnostics { get; init; }
    public TsData DisaggregatedSeries { get; init; }
    public TsData StDevDisaggregatedSeries { get; init; }
    public Option<TsData> RegressionEffects { get; init; }
}
