namespace JDPlus.WS.Models;

public readonly record struct ResidualsDiagnostics
{
    public TsData FullResiduals { get; init; }
    public NiidTests Niid { get; init; }
}
