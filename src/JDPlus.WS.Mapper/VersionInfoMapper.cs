using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class VersionInfoMapper
{
    extension(VersionInfo model)
    {
        public VersionInfoDto ToDto() =>
            new()
            {
                Major = model.Major,
                Minor = model.Minor,
                Revision = model.Revision,
            };
    }

    extension(VersionInfoDto dto)
    {
        public VersionInfo ToModel() =>
            new(dto.Major, dto.Minor, dto.Revision);
    }
}
