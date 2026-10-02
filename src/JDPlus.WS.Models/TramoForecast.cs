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
}

public readonly record struct TramoForecast(
    double Forecast,
    double ForecastStDev,
    double RawForecast,
    double RawForecastStDev
);
