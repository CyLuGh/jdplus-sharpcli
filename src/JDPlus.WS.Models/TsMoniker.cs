namespace JDPlus.WS.Models;

public readonly record struct TsMoniker
{
    public TsMoniker() { }

    public static TsMoniker Default => new() { Id = "Default", Source = "Default" };

    public string Source { get; init; } = string.Empty;
    public required string Id { get; init; }
}
