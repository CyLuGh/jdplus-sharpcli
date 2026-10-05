namespace JDPlus.WS.Models;

public readonly record struct EasterRelatedDay(
    int Offset,
    bool Julian,
    double Weight,
    ValidityPeriod Validity
);
