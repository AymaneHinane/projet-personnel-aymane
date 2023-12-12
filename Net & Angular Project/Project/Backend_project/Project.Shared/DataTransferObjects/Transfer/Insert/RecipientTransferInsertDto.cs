

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.Dto;


public class RecipientTransferInsertDto{


    public Guid RecipientId{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal DeliveredStock {get;set;}

}