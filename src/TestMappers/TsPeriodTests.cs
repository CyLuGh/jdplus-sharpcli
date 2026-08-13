using FluentAssertions;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using Xunit;

namespace TestMappers;

public class TsPeriodTests
{
    [Theory]
    [InlineData(1999, 1, JDPlus.WS.Models.Frequency.HalfYearly)]
    [InlineData(2005, 2, JDPlus.WS.Models.Frequency.Monthly)]
    public void ToDtoAndBack(int year, int position, JDPlus.WS.Models.Frequency frequency)
    {
        var tsPeriod = new TsPeriod()
        {
            Frequency = frequency,
            Year = year,
            Position = position
        };

        var dto = tsPeriod.ToDto();
        var model = dto.ToModel();

        tsPeriod.Should().BeEquivalentTo(model);
    }

    [Theory]
    [InlineData(1999, 1, JDPlus.Main.WS.V1.Frequency.FreqHalfYearly)]
    [InlineData(2015, 3, JDPlus.Main.WS.V1.Frequency.FreqMonthly)]
    public void ToModelAndBack(int year, int position, JDPlus.Main.WS.V1.Frequency frequency)
    {
        var tsPeriod = new TsPeriodDto()
        {
            Frequency = frequency,
            Year = year,
            Pos = position
        };

        var model = tsPeriod.ToModel();
        var dto = model.ToDto();

        tsPeriod.Should().BeEquivalentTo(dto);
    }
}
