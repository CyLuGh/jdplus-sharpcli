using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using LanguageExt.Common;

namespace JDPlus.WS.Mapper;

public static class TsDataMapper
{
    public static TsDataDto ToDto(this TsData model)
    {
        TsDataDto dto = new() { Start = model.Start.ToDto() };
        dto.Values.AddRange(model.Values);
        return dto;
    }

    public static TsData ToModel(this TsDataDto dto) =>
        new() { Start = dto.Start.ToModel(), Values = dto.Values.ToSeq() };

    public static Either<Error, TsData> ToResult(this BuildTsDataResponseDto dto) =>
        dto.ResultCase switch
        {
            BuildTsDataResponseDto.ResultOneofCase.Ok => dto.Ok.ToModel(),
            BuildTsDataResponseDto.ResultOneofCase.Err => Error.New(dto.Err.Message),
            _ => Error.New("Unknown result case"),
        };
}
