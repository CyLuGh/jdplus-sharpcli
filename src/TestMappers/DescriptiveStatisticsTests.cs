using FluentAssertions;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using Xunit;
using ResultStatusType = JDPlus.WS.Models.ResultStatusType;

namespace TestMappers;

public class DescriptiveStatisticsTests
{
    [Fact]
    public void ToDtoAndBack()
    {
        var ds = new DescriptiveStatistics
        {
            Id = "Test",
            N = 4,
            Average = 2.5,
            StDev = 1.118033988749895,
            Min = 1,
            Max = 4,
            NMissing = 0,
            Q25 = 1.75,
            Q50 = 2.5,
            Q75 = 3.25,
            Status = new ResultStatus { Type = ResultStatusType.StatusOk, Message = "Success" }
        };

        var dto = ds.ToDto();
        var model = dto.ToModel();

        ds.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void ToToolkitAndBack()
    {
        var ds = new DescriptiveStatisticsDto
        {
            Id = "Test",
            N = 4,
            Average = 2.5,
            Stdev = 1.118033988749895,
            Min = 1,
            Max = 4,
            Nmissing = 0,
            Q25 = 1.75,
            Q50 = 2.5,
            Q75 = 3.25,
            Status = new ResultStatusDto()
            {
                Type = JDPlus.Main.WS.V1.ResultStatusType.StatusOk,
                Message = "Success"
            }
        };

        var model = ds.ToModel();
        var dto = model.ToDto();

        ds.Should().BeEquivalentTo(dto);
    }
}
