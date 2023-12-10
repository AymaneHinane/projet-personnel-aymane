

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Project.Entities.Models;


public class RecipientTransfer{

    public Guid Id{ get; set;}

    public Guid RecipientId{get;set;}
    public Recipients? Recipient{get;set;}

    public Guid TransferOperationId { get; set; }
    [IgnoreDataMember]
    public TransferOperation? transferOperation{get;set;}


    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal DeliveredStock {get;set;}
    public TransferStatus TransferStatus {get;set;} = TransferStatus.delivery;
}