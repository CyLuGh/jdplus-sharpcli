namespace JDPlus.WS.Models;

public readonly record struct ChainedCalendar(
    string Calendar1,
    string Calendar2,
    DateOnly BreakDate
);
