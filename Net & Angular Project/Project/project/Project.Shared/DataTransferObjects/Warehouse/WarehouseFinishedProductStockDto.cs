


using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class WarehouseFinishedProductStockDto:WarehouseStockInfoDto{

      public ICollection<FinishedProductStockDto>? Stocks {get;set;}
}