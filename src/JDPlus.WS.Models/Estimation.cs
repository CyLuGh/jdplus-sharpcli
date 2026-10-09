using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Estimation
{
    public Seq<double> Y { get; init; }
    public Matrix X { get; init; }
    public Seq<double> B { get; init; }
    public Matrix BCovariance { get; init; }
    public ParametersEstimation Parameters { get; init; }
    public LikelihoodStatistics Likelihood { get; init; }
    public Seq<double> Residuals { get; init; }
    public Seq<MissingEstimation> Missings { get; init; }
}
