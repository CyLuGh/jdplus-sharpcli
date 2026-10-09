using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class ProcessingDetailMapper
{
    public static ProcessingDetail ToModel(this ProcessingDetailDto dto) =>
        dto.DataCase switch
        {
            ProcessingDetailDto.DataOneofCase.Array => new(dto.Array.ToModel()),
            ProcessingDetailDto.DataOneofCase.Matrix => new(dto.Matrix.ToModel()),
            ProcessingDetailDto.DataOneofCase.Ts => new(dto.Ts.ToModel()),
            ProcessingDetailDto.DataOneofCase.Test => new(dto.Test.ToModel()),
            ProcessingDetailDto.DataOneofCase.Dvalue => new(dto.Dvalue),
            ProcessingDetailDto.DataOneofCase.Ivalue => new(dto.Ivalue),
            ProcessingDetailDto.DataOneofCase.Message => new(dto.Message),
            _ => throw new ArgumentException("Invalid data case"),
        };
}
