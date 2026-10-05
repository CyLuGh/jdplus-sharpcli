using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;

namespace JDPlus.WS.Mapper;

public static class TsDataSuppliersMapper
{
    public static TsDataSuppliersDto ToDto(this TsDataSuppliers model)
    {
        TsDataSuppliersDto dto = new();
        dto.Items.AddRange(
            model.Items.Select(x =>
                x.Supplier.Match(
                    dynamicTsData => new TsDataSuppliersDto.Types.ItemDto
                    {
                        Name = x.Name,
                        DynamicData = dynamicTsData.ToDto()
                    },
                    tsData => new TsDataSuppliersDto.Types.ItemDto
                    {
                        Name = x.Name,
                        Data = tsData.ToDto()
                    }
                )
            )
        );
        return dto;
    }

    public static TsDataSuppliers ToModel(this TsDataSuppliersDto dto) =>
        new()
        {
            Items = dto
                .Items.Select(x =>
                    x.SupplierCase switch
                    {
                        TsDataSuppliersDto.Types.ItemDto.SupplierOneofCase.DynamicData
                            => new TsDataSuppliers.Item()
                            {
                                Name = x.Name,
                                Supplier = x.DynamicData.ToModel()
                            },
                        TsDataSuppliersDto.Types.ItemDto.SupplierOneofCase.Data
                            => new TsDataSuppliers.Item()
                            {
                                Name = x.Name,
                                Supplier = x.Data.ToModel()
                            },
                        _ => throw new ArgumentException("Invalid supplier case")
                    }
                )
                .ToSeq()
        };
}
