


using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.Dto;


public class RawMaterilaStockDto{

    public Guid warehouseId{get;set;}
    public Guid productId{get;set;}
    public string? productName{get;set;}

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OrderStock {get;set;} 

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliverStock {get;set;} 

    [Column(TypeName = "decimal(18, 2)")]
    public decimal?  ConsumeStock {get;set;} 

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RemainingStock {get;set;}  

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LastYearRemainingStock {get;set;}  

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DAPStock {get;set;}  

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockExitTotal {get;set;}  

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockEntryTotal {get;set;}  

}