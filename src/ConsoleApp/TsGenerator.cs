using JDPlus.WS.Models;
using LanguageExt;

namespace ConsoleApp;

public class TsGenerator
{
    public Seq<Ts> GenerateTs() =>
        new[]
        {
            GenerateTs(2000, 0, Frequency.Monthly, 120),
            GenerateTs(2001, 1, Frequency.Quarterly, 24),
            GenerateTs(2000, 5, Frequency.Monthly, 112),
            GenerateTs(2000, frequency: Frequency.Yearly),
        }.ToSeq();

    public Ts GenerateTs(
        int year = 2000,
        int position = 0,
        Frequency frequency = Frequency.Yearly,
        int count = 10
    )
    {
        return new()
        {
            Name = $"{year}/{position}/{frequency}/{count}",
            Moniker = new() { Source = "Test", Id = Guid.CreateVersion7().ToString() },
            Data = GenerateTsData(year, position, frequency, count),
        };
    }

    public TsData GenerateTsData(
        int year = 2000,
        int position = 0,
        Frequency frequency = Frequency.Yearly,
        int count = 10
    ) =>
        new()
        {
            Start = new()
            {
                Year = year,
                Position = position,
                Frequency = frequency,
            },
            Values = Enumerable
                .Range(0, count)
                .Map(_ => Random.Shared.NextDouble() * 1_000)
                .ToSeq()
                .Strict(),
        };
}
