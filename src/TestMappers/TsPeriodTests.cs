using FluentAssertions;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using Xunit;

namespace TestMappers
{
    public class TsPeriodTests
    {
        [Fact]
        public void ToDtoAndBack()
        {
            var tsPeriod = new TsPeriod()
            {
                Frequency = JDPlus.WS.Models.Frequency.HalfYearly,
                Year = 1999,
                Position = 1
            };

            var dto = tsPeriod.ToDto();
            var toolkit = dto.ToModel();

            tsPeriod.Should().BeEquivalentTo(toolkit);
        }

        [Fact]
        public void ToToolkitAndBack()
        {
            var tsPeriod = new TsPeriodDto()
            {
                Frequency = JDPlus.Main.WS.V1.Frequency.FreqHalfYearly,
                Year = 1999,
                Pos = 1
            };

            var toolkit = tsPeriod.ToModel();
            var dto = toolkit.ToDto();

            tsPeriod.Should().BeEquivalentTo(dto);
        }
    }
}
