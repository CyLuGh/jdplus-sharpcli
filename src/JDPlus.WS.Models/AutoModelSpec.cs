namespace JDPlus.WS.Models;

public readonly record struct AutoModelSpec
{
    public bool Enabled { get; init; }
    public double Cancel { get; init; }
    public double Ub1 { get; init; }
    public double Ub2 { get; init; }
    public double Pcr { get; init; }
    public double Pc { get; init; }
    public double Tsig { get; init; }
    public bool AcceptDef { get; init; }
    public bool AmiCompare { get; init; }
}
