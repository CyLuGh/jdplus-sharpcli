using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsDataMapper
{
    extension(TsData model)
    {
        public TsDataDto ToDto()
        {
            TsDataDto dto = new(){ Start = model.Start.ToDto()};
            dto.Values.AddRange( model.Values);
            return dto;
        }
    }

    extension(TsDataDto dto)
    {
        public TsData ToModel() => new() { Start = dto.Start.ToModel(), 
            Values = dto.Values.ToSeq() };
    }
}