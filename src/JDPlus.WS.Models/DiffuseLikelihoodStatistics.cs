namespace JDPlus.WS.Models;

public readonly record struct DiffuseLikelihoodStatistics
{
    public int NObs { get; init; }
    public int NDiffuse { get; init; }
    public int NParams { get; init; }
    public int DegreesOfFreedom { get; init; }
    public double LogLikelihood { get; init; }
    public double AdjustedLogLikelihood { get; init; }
    public double Aic { get; init; }
    public double Aicc { get; init; }
    public double Bic { get; init; }
    public double Ssq { get; init; }
    public double LDet { get; init; }
    public double DCorrection { get; init; }
}
