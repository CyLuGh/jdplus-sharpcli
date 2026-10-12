using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class MatrixMapper
{
    public static Matrix ToModel(this MatrixDto dto) =>
        new()
        {
            NColumns = dto.Ncols,
            NRows = dto.Nrows,
            Values = dto.Values.ToSeq()
        };

    public static MatrixDto ToDto(this Matrix model)
    {
        MatrixDto dto = new() { Ncols = model.NColumns, Nrows = model.NRows };
        dto.Values.AddRange(model.Values);
        return dto;
    }

    public static TsMatrix ToModel(this TsMatrixDto dto) =>
        new(dto.Start.ToModel(), dto.Values.ToModel());
}
