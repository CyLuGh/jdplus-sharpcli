using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class DoublesMapper
{
    public static Doubles ToModel(this DoublesDto dto) =>
        new(dto.Name, dto.Values.ToSeq().Strict());
}
