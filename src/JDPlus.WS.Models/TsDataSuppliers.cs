using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct TsDataSuppliers
{
    public readonly record struct Item
    {
        public string Name { get; init; }
        public Either<TsData, DynamicTsData> Supplier { get; init; }
    }

    public Seq<Item> Items { get; init; }
}
