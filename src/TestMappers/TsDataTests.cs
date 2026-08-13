using FluentAssertions;
using JDPlus.WS.Models;
using LanguageExt;
using Xunit;

namespace TestMappers;

public class TsDataTests
{
    [Theory]
    [InlineData(2000, 0, Frequency.Monthly, 2000, 3)]
    [InlineData(2000, 0, Frequency.BiMonthly, 2000, 5)]
    [InlineData(2000, 0, Frequency.Quarterly, 2000, 7)]
    [InlineData(2000, 0, Frequency.QuadriMonthly, 2000, 9)]
    [InlineData(2000, 0, Frequency.HalfYearly, 2001, 1)]
    [InlineData(2000, 0, Frequency.Yearly, 2002, 1)]
    public void TestGetDateValues(
        int year,
        int position,
        Frequency frequency,
        int expectedYear,
        int expectedMonth
    )
    {
        var data = new TsData
        {
            Start = new TsPeriod
            {
                Year = year,
                Position = position,
                Frequency = frequency
            },
            Values = Seq.createRange([1d, 2d, 3d])
        };

        var map = data.GetDateValues();
        var keys = map.Keys.Order().ToSeq();

        keys.Last.Year.Should().Be(expectedYear);
        keys.Last.Month.Should().Be(expectedMonth);
    }

    [Fact]
    public void TestMapData()
    {
        var data = new TsData
        {
            Start = new TsPeriod
            {
                Year = 2000,
                Position = 0,
                Frequency = Frequency.Monthly
            },
            Values = Seq.createRange([1d, 2d, 3d])
        };

        var altered = data.MapData((d, x) => d * x, .5);
        altered.Values.Should().BeEquivalentTo(Seq.createRange([.5, 1d, 1.5]));
    }
}
