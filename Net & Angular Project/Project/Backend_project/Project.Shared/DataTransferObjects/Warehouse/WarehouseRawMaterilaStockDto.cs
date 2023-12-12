

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.Dto;


public class WarehouseRawMaterilaStockDto:WarehouseStockInfoDto{


    public ICollection<RawMaterilaStockDto>? Stocks {get;set;}

   

}