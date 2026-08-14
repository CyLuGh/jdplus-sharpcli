using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct ObjectiveFunctionPoint
{
    public double Value { get; init; }
    public Seq<double> Parameters { get; init; }
    public Seq<double> Gradient { get; init; }
    public Matrix Hessian { get; init; }
}
