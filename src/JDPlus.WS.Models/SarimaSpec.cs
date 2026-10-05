using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct SarimaSpec
{
    public int Period { get; init; }
    public Seq<Parameter> Phi { get; init; }
    public int D { get; init; }
    public Seq<Parameter> Theta { get; init; }
    public Seq<Parameter> BPhi { get; init; }
    public int BD { get; init; }
    public Seq<Parameter> BTheta { get; init; }
}
