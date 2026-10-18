using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TramoOutput
{
    public readonly record struct OutlierReport(DateOnly Period, double Value, string Code);

    public RegArimaModel Result { get; init; }
    public TramoSpec EstimationSpec { get; init; }
    public Option<TramoSpec> ResultSpec { get; init; }
    public Option<ProcessingLogs> Log { get; init; }

    public Seq<OutlierReport> GetOutliers()
    {
        var seriesValues = Result.Description.Series.GetDateValues();
        return ResultSpec.Match(
            rs =>
                rs.Regression.Outliers.Select(o =>
                    {
                        return seriesValues.Find(
                            o.Position,
                            v => new OutlierReport(o.Position, v, o.Code),
                            () => Option<OutlierReport>.None
                        );
                    })
                    .Somes(),
            () => Seq<OutlierReport>.Empty
        );
    }
}
