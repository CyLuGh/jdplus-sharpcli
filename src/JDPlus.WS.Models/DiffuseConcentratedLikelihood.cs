using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct DiffuseConcentratedLikelihood
{
    public double Ll { get; init; }
    public double SsqErr { get; init; }
    public double LDet { get; init; }
    public double LdDet { get; init; }
    public int NObs { get; init; }
    public int Nd { get; init; }
    public int Nxd { get; init; }
    public Seq<double> Res { get; init; }
    public Seq<double> B { get; init; }
    public Matrix Bvar { get; init; }
    public bool Legacy { get; init; }
    public bool ScalingFactor { get; init; }
}
