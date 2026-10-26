using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TramoOutput
{
    public readonly record struct OutlierReport
    {
        public DateOnly Period { get; init; }
        public double Value { get; init; }
        public string Code { get; init; }
        public Parameter Coefficient { get; init; }
        public HashMap<string, string> Metadata { get; init; }

        public OutlierReport(DateOnly Period, double Value, string Code)
        {
            this.Period = Period;
            this.Value = Value;
            this.Code = Code;
        }
    }

    public RegArimaModel Result { get; init; }
    public TramoSpec EstimationSpec { get; init; }
    public Option<TramoSpec> ResultSpec { get; init; }
    public Option<ProcessingLogs> Log { get; init; }
    public Option<string> FailureMessage { get; init; }

    public Seq<OutlierReport> GetOutliers()
    {
        var seriesValues = Result.Description.Series.GetDateValues();
        return ResultSpec.Match(
            rs =>
                rs.Regression.Outliers.Select(o =>
                    {
                        return seriesValues.Find(
                            o.Position,
                            v => new OutlierReport(o.Position, v, o.Code)
                            {
                                Coefficient = o.Coefficient,
                                Metadata = o.MetaData
                            },
                            () => Option<OutlierReport>.None
                        );
                    })
                    .Somes(),
            () => Seq<OutlierReport>.Empty
        );
    }
}
