using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Outlier
{
    public string Name { get; init; }
    public string Code { get; init; }
    public DateOnly Position { get; init; }
    public Parameter Coefficient { get; init; }
    public HashMap<string, string> MetaData { get; init; }
}
