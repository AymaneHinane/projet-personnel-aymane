

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.Dto;

public class ProductUpdateDto{

    //RawMaterial
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OrderStock {get;set;} 

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliverStock {get;set;} 

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal?  ConsumeStock {get;set;}

    [Range(0, double.MaxValue)]
    //FinishedProduct
     [Column(TypeName = "decimal(18, 2)")]
    public decimal? StockProduced {get;set;} 

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? WarehouseDeliverStock {get;set;} 

    // [Range(0, double.MaxValue)]
    // [Column(TypeName = "decimal(18, 2)")]
    // public decimal? CdaDeliverStock {get;set;} 

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RemainingStock {get;set;} 

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockExitTotal {get;set;}  

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockEntryTotal {get;set;}  

}