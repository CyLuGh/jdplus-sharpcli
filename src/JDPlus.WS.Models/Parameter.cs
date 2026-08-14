namespace JDPlus.WS.Models;

public readonly record struct Parameter
{
    public double Value { get; init; }
    public ParameterType Type { get; init; }
    public string Description { get; init; }
}