

using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class FinishedProductStockDto{

    public Guid warehouseId{get;set;}
    public Guid productId{get;set;}

    public string? productName{get;set;}
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? StockProduced {get;set;} 

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockExitTotal {get;set;}  
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RemainingStock {get;set;} 
}