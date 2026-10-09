using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TramoOutput
{
    public RegArimaModel Result { get; init; }
    public TramoSpec EstimationSpec { get; init; }
    public Option<TramoSpec> ResultSpec { get; init; }
    public Option<ProcessingLogs> Log { get; init; }
}
