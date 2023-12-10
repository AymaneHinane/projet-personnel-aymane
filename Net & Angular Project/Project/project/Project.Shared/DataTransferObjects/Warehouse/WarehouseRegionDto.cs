using Project.Entities.Models;

namespace Project.Shared.Dto;


public class WarehouseRegionDto{
    public WarehouseRegion? WarehouseRegion {get;set;}
    public ICollection<WarehouseInfoDto>? WarehouseInfo{get;set;}
}