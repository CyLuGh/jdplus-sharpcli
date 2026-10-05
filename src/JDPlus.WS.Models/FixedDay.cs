namespace JDPlus.WS.Models;

public readonly record struct FixedDay(int Month, int Day, double Weight, ValidityPeriod Validity);
