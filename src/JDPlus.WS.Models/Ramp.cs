using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Ramp
{
    public string Name { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }
    public Parameter Coefficient { get; init; }
    public HashMap<string, string> MetaData { get; init; }
}
