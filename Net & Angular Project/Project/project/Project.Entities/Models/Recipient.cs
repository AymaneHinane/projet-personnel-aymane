

using System.Runtime.Serialization;

namespace Project.Entities.Models;

public class Recipients{


    public Guid Id{get;set;}


    public Guid TransferId{get;set;}
    [IgnoreDataMember]
    public Transfer? Transfer {get;set;}

    public Guid RecipientId{get;set;}
    public Warehouse? Recipient{get;set;}       

     [IgnoreDataMember]
    public ICollection<RecipientTransfer>? RecipientTransfers{get;set;}          
}