namespace JDPlus.WS.Models;

public readonly record struct TramoSpec
{
    public BasicSpec Basic { get; init; }
    public TransformSpec Transform { get; init; }
    public OutlierSpec Outlier { get; init; }
    public SarimaSpec Arima { get; init; }
    public AutoModelSpec AutoModel { get; init; }
    public RegressionSpec Regression { get; init; }
    public EstimateSpec Estimate { get; init; }
}
