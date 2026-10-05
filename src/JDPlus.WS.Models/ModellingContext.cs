using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct ModellingContext
{
    public HashMap<string, CalendarDefinition> Calendars { get; init; }
    public HashMap<string, TsDataSuppliers> Variables { get; init; }
}
