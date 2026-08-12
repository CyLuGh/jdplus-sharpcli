using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DescriptiveStatisticsMapper
{
    extension(DescriptiveStatistics model)
    {
        public DescriptiveStatisticsDto ToDto() => new()
        {
            Id = model.Id,
            N = model.N,
            Nmissing = model.NMissing,
            Average = model.Average,
            Q25 = model.Q25,
            Q50 = model.Q50,
            Q75 = model.Q75,
            Min = model.Min,
            Max = model.Max,
            Stdev = model.StDev,
            Status = model.Status.ToDto()
        };
    }

    extension(DescriptiveStatisticsDto dto)
    {
        public DescriptiveStatistics ToModel() => new()
        {
            Id = dto.Id,
            N = dto.N,
            NMissing = dto.Nmissing,
            Average = dto.Average,
            Q25 = dto.Q25,
            Q50 = dto.Q50,
            Q75 = dto.Q75,
            Min = dto.Min,
            Max = dto.Max,
            StDev = dto.Stdev,
            Status = dto.Status.ToModel()
        };
    }
}