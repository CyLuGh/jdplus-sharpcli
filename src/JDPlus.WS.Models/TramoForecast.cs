using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TramoForecasts
{
    public HashMap<DateOnly, TramoForecast> Forecasts { get; }

    public TramoForecasts(TsMatrix matrix)
    {
        List<TramoForecast> tfs = [];
        for (int i = 0; i < matrix.Matrix.Values.Length; i += 4)
        {
            tfs.Add(
                new TramoForecast(
                    matrix.Matrix.Values[i],
                    matrix.Matrix.Values[i + 1],
                    matrix.Matrix.Values[i + 2],
                    matrix.Matrix.Values[i + 3]
                )
            );
        }

        var start = matrix.Start.ToDate();
        Forecasts = tfs.Select(
                (f, i) => (start.AddMonths(i * matrix.Start.MonthlyOccurrencesPerYear), f)
            )
            .ToHashMap();
    }
}

public readonly record struct TramoForecast(
    double Forecast,
    double ForecastStDev,
    double RawForecast,
    double RawForecastStDev
);
