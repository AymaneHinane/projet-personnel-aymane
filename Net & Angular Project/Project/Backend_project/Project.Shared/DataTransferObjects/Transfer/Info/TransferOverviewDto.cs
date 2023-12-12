
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class TransferOverviewDto{
    public int RecipientNbr{get;set;}

    public int TransferOperationNbr{get;set;}
    public int DeliveryNbr{get;set;}
    public int ShippedNbr{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockQuantity {get;set;}
    
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockQuantityTotal{get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockQuantityShipped{get;set;} = 0;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PercentageTransferStatus {get;set;} 
    
}