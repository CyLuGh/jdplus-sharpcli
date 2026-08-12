using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TimeSeriesMapper
{
    extension(TimeSeries model)
    {
        public TimeSeriesDto ToDto()
        {
            TimeSeriesDto dto = new()
            {
                Moniker = model.Moniker.ToDto(),
                Name = model.Name
            };

            dto.Observations.AddRange(model.Observations.Map(x => x.ToDto()));
            foreach ((string key, string value) in model.Metadata)
                dto.Metadata.Add(key, value);

            return dto;
        }
    }

    extension(TimeSeriesDto dto)
    {
        public TimeSeries ToModel() => new()
        {
            Moniker = dto.Moniker.ToModel(),
            Name = dto.Name,
            Observations = dto.Observations.Map(x => x.ToModel()).ToSeq(),
            Metadata = dto.Metadata.Select(x => (x.Key, x.Value)).ToHashMap()
        };
    }
}