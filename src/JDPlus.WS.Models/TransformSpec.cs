namespace JDPlus.WS.Models;

public readonly record struct TransformSpec
{
    public Transformation Transformation { get; init; }
    public double Fct { get; init; }
    public LengthOfPeriod Adjust { get; init; }
    public bool OutliersCorrection { get; init; }
}
