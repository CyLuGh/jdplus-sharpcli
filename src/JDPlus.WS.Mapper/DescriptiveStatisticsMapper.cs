using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using LanguageExt.Common;

namespace JDPlus.WS.Mapper;

public static class DescriptiveStatisticsMapper
{
    public static DescriptiveStatisticsDto ToDto(this DescriptiveStatistics model) =>
        new()
        {
            N = model.N,
            Nmissing = model.NMissing,
            Average = model.Average,
            Q25 = model.Q25,
            Q50 = model.Q50,
            Q75 = model.Q75,
            Min = model.Min,
            Max = model.Max,
            Stdev = model.StDev,
            Status = model.Status.ToDto(),
        };

    public static DescriptiveStatistics ToModel(this DescriptiveStatisticsDto dto) =>
        new()
        {
            N = dto.N,
            NMissing = dto.Nmissing,
            Average = dto.Average,
            Q25 = dto.Q25,
            Q50 = dto.Q50,
            Q75 = dto.Q75,
            Min = dto.Min,
            Max = dto.Max,
            StDev = dto.Stdev,
            Status = dto.Status.ToModel(),
        };

    public static Option<DescriptiveStatistics> ToModel(
        this DescriptiveStatisticsResponseDto dto
    ) =>
        dto.ResultCase switch
        {
            DescriptiveStatisticsResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
            _ => Option<DescriptiveStatistics>.None,
        };

    public static Either<Error, DescriptiveStatistics> ToResult(
        this DescriptiveStatisticsResponseDto dto
    ) =>
        dto.ResultCase switch
        {
            DescriptiveStatisticsResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
            DescriptiveStatisticsResponseDto.ResultOneofCase.Err => Error.New(dto.Err.Message),
            _ => throw new ArgumentOutOfRangeException(
                nameof(dto.ResultCase),
                dto.ResultCase,
                null
            ),
        };
}
