

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class RecipientTransferInfoDto{
    public Guid Id{ get; set;}
    [Range(0, double.MaxValue)]

    public string? Name{get;set;}
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal DeliveredStock {get;set;}
    public TransferStatus TransferStatus {get;set;} = TransferStatus.delivery;
}