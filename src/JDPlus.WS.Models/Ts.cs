using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Ts
{
    public Ts() { }

    public static Ts Default =>
        new()
        {
            Name = "Default",
            Data = TsData.Default,
            Moniker = TsMoniker.Default
        };

    public string Name { get; init; } = string.Empty;
    public required TsMoniker Moniker { get; init; }
    public required TsData Data { get; init; }
    public HashMap<string, string> Metadata { get; init; } = HashMap<string, string>.Empty;
}
