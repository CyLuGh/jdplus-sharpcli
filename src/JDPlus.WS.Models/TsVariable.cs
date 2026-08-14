using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TsVariable
{
    public string Name { get; init; }
    public string Id { get; init; }
    public int Lag { get; init; }
    public Parameter Coefficient { get; init; }
    public HashMap<string, string> MetaData { get; init; }
}
