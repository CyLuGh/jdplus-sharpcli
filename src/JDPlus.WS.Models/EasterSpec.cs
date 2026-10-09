using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct EasterSpec
{
    public EasterType Type { get; init; }
    public int Duration { get; init; }
    public bool Julian { get; init; }
    public bool Test { get; init; }
    public Option<Parameter> Coefficient { get; init; }
}
