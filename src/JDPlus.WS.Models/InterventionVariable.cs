using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct InterventionVariable
{
    public readonly record struct Sequence(DateOnly Start, DateOnly End);

    public string Name { get; init; }
    public Seq<Sequence> Sequences { get; init; }
    public double Delta { get; init; }
    public double SeasonalDelta { get; init; }
    public Parameter Coefficient { get; init; }
    public HashMap<string, string> MetaData { get; init; }
}
