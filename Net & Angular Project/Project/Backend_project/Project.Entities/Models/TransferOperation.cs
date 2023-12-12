
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Event;

namespace Project.Entities.Models;



public class TransferOperation:Entity{
    public Guid Id {get;set;}
     
    public Guid TransferId{get;set;}
    public Transfer? Transfer{get;set;}

    public ICollection<RecipientTransfer>? RecipientTransfers{get;set;}

    public string? TruckNumber {get;set;}

    public DateTime? DeliveryDate{get;set;} =  DateTime.Now;

    public DateTime? ShippedDate{get;set;} = null;


    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ExitStockWeight{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? EntryStockWeight{get;set;}


    public byte[]? ExitVoucher{get;set;} = null;


    public byte[]? EntryVoucher {get;set;} = null;


    public TransferStatus TransferStatus {get;set;} = TransferStatus.delivery;


}
