


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Project.Entities.Event;


namespace Project.Entities.Models;


public enum TransferStatus{
     delivery, shipped
}


public class Transfer:Entity{

    public Guid Id {get;set;}
    public int Numero{get;set;}

    public Guid SenderId{get;set;}
    public Warehouse? Sender{get;set;}

    [IgnoreDataMember]
    public ICollection<Recipients>? Recipients {get;set;}

    public WarehouseType DestinationType {get;set;}

    public ICollection<TransferOperation>? TransferOperations{get;set;}

    public Guid ProductId{get;set;}

    public Product? Product {get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransferedStockQuantity{get;set;} 

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliveredStockQuantity{get;set;} 

    public TransferStatus TransferStatus {get;set;} 
    
    public DateTime? DeliveryDate{get;set;} = DateTime.Now;

    public DateTime? ShippedDate{get;set;} = null;

    public ICollection<TransferHistory>? TransferHistory{get;set;}

    public void CreatedRaiseEvent(){
        this.RaiseDomainEvent(new TransferCreatedDomainEvent(this));
    }

    public void UpdatedRaiseEvent(){
        this.RaiseDomainEvent(new TransferUpdatedDomainEvent(this));
    }
}