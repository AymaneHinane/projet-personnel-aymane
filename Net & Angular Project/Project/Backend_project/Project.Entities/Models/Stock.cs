


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Project.Entities.Models;

public class Stock{

   public Guid Id{get;set;}

   public Guid warehouseId{get;set;}
   public Guid productId{get;set;}
   
   public Warehouse? warehouse{get;set;}
   [IgnoreDataMember]
   public Product? product{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? StockProduced {get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RemainingStock {get;set;}  = 0;


    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OrderStock {get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliverStock {get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal?  ConsumeStock {get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LastYearRemainingStock {get;set;}  = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DAPStock {get;set;}  = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockEntryTotal {get;set;}  = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockExitTotal {get;set;}  = 0;


    [Required(ErrorMessage = "Stock year is  a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Stock year is 4 characters.")]
    public string? Year;
   
}