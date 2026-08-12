using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsMonikerMapper
{
    extension(TsMoniker model)
    {
        public TsMonikerDto ToDto() => new() { Id = model.Id, Source = model.Source };
    }

    extension(TsMonikerDto dto)
    {
        public TsMoniker ToModel() => new() { Id = dto.Id, Source = dto.Source };
    }
}