using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct WeightedCalendar
{
    public readonly record struct Item(string Calendar, double Weight);

    public Seq<Item> Items { get; init; }
}
