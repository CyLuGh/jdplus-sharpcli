using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TimeSeries
{
    public TimeSeries() { }

    public string Name { get; init; } = string.Empty;
    public required TsMoniker Moniker { get; init; }
    public required Seq<TsObservation> Observations { get; init; }
    public HashMap<string, string> Metadata { get; init; } = HashMap<string, string>.Empty;

    public HashMap<DateOnly, double> ObservationsMap =>
        Observations.Map(o => (o.Start, o.Value)).ToHashMap();
}
