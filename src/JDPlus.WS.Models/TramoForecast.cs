using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TramoForecasts
{
    public HashMap<DateOnly, TramoForecast> Forecasts { get; }

    public TramoForecasts(
        DateOnly lastObservationDate,
        int monthlyOccurrencesPerYear,
        params IEnumerable<TramoForecast> forecasts
    )
    {
        Forecasts = forecasts
            .Select((f, i) => (lastObservationDate.AddMonths(i * monthlyOccurrencesPerYear), f))
            .ToHashMap();
    }

    public TramoForecasts(TsData series, Matrix matrix)
    {
        List<TramoForecast> tfs = [];
        for (int i = 0; i < matrix.Values.Length; i += 4)
        {
            tfs.Add(
                new TramoForecast(
                    matrix.Values[i],
                    matrix.Values[i + 1],
                    matrix.Values[i + 2],
                    matrix.Values[i + 3]
                )
            );
        }

        Forecasts = tfs.Select(
                (f, i) => (series.End.AddMonths(i * series.MonthlyOccurrencesPerYear), f)
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
