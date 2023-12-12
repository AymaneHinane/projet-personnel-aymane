
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class TransferOperationInfoDto{

    public Guid Id {get;set;}     

    public string? TruckNumber {get;set;}

    public DateTime? DeliveryDate{get;set;} =  DateTime.Now;

    public DateTime? ShippedDate{get;set;} = null;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ExitStockWeight{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? EntryStockWeight{get;set;}

    public bool ExitVoucherExist{get;set;}
    public bool EntryVoucherExist{get;set;}

    public TransferStatus TransferStatus {get;set;} = TransferStatus.delivery;

    public ICollection<RecipientTransferInfoDto>? RecipientTransfer{get;set;}
}