using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class MatrixMapper
{
    extension(MatrixDto dto)
    {
        public Matrix ToModel() => new()
        {
            NColumns = dto.Ncols,
            NRows = dto.Nrows,
            Values = dto.Values.ToSeq()
        };
    }

    extension(Matrix model)
    {
        public MatrixDto ToDto()
        {
            MatrixDto dto = new()
            {
                Ncols = model.NColumns,
                Nrows = model.NRows
            };
            dto.Values.AddRange(model.Values);
        }
    }
}