

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;


public class RecipientTransferUpdateDto{

    public Guid Id{ get; set;}
  
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliveredStock {get;set;}
    public TransferStatus? TransferStatus {get;set;}

}