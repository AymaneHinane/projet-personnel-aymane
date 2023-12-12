
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class TransferOperationUpdateDto{

    public string? TruckNumber {get;set;}

    public DateTime? DeliveryDate{get;set;} =  DateTime.Now;

    public DateTime? ShippedDate{get;set;} = null;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ExitStockWeight{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? EntryStockWeight{get;set;}
    
    public TransferStatus? TransferStatus {get;set;}
}