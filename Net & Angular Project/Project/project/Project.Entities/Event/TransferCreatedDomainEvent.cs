
using Project.Entities.Models;

namespace Project.Entities.Event;

public  enum DeliveryOperation{
   addDelivery,
   updateDelivery,
}


public class TransferCreatedDomainEvent:IDomainEvent{

    public  Transfer? transfer {get;}
    // public  DeliveryOperation operation{get;} 

    public TransferCreatedDomainEvent(Transfer? transfer){
         this.transfer = transfer;
        //  this.operation = operation;
    }
}