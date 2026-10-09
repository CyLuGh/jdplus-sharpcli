namespace JDPlus.WS.Models;

public readonly record struct LikelihoodStatistics
{
    public int NObs { get; init; }
    public int NEffectiveObs { get; init; }
    public int NParams { get; init; }
    public int DegreesOfFreedom { get; init; }
    public double LogLikelihood { get; init; }
    public double AdjustedLogLikelihood { get; init; }
    public double Aic { get; init; }
    public double Aicc { get; init; }
    public double Bic { get; init; }
    public double Bicc { get; init; }
    public double Bic2 { get; init; }
    public double HannanQuinn { get; init; }
    public double Ssq { get; init; }
}
