using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class StatisticalTestMapper
{
    extension(StatisticalTestDto dto)
    {
        public StatisticalTest ToModel()
            => new() { Value = dto.Value, PValue = dto.PValue, Description = dto.Description };
    }
}