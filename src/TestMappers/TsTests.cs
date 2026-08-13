using FluentAssertions;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using LanguageExt;
using Xunit;

namespace TestMappers;

public class TsTests
{
    [Fact]
    public void ToDtoAndBack()
    {
        var ts = new Ts()
        {
            Name = "Test",
            Moniker = new TsMoniker { Id = "Id", Source = "UnitTests" },
            Metadata = new[] { ("Meta", "Data"), ("M", "D") }.ToHashMap(),
            Data = new TsData
            {
                Start = new TsPeriod
                {
                    Year = 2000,
                    Position = 0,
                    Frequency = JDPlus.WS.Models.Frequency.Monthly
                },
                Values = Seq.createRange([1d, 2d, 3d])
            }
        };

        var dto = ts.ToDto();
        var model = dto.ToModel();

        ts.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void ToToolkitAndBack()
    {
        var ts = new TsDto()
        {
            Name = "Test",
            Moniker = new TsMonikerDto { Id = "Id", Source = "UnitTests" },
            Data = new TsDataDto
            {
                Start = new TsPeriodDto
                {
                    Year = 2000,
                    Pos = 0,
                    Frequency = JDPlus.Main.WS.V1.Frequency.FreqMonthly
                }
            }
        };

        ts.Data.Values.AddRange([1d, 2d, 3d]);
        ts.Metadata.Add("Meta", "Data");
        ts.Metadata.Add("M", "D");

        var model = ts.ToModel();
        var dto = model.ToDto();

        ts.Should().BeEquivalentTo(dto);
    }
}
