namespace JDPlus.WS.Models;

public readonly record struct PrespecifiedHoliday(
    CalendarEvent Event,
    int Offset,
    double Weight,
    ValidityPeriod Validity
);
