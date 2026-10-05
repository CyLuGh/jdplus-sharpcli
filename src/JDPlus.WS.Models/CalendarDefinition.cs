using OneOf;

namespace JDPlus.WS.Models;

public readonly record struct CalendarDefinition(
    OneOf<Calendar, WeightedCalendar, ChainedCalendar> Definition
);
