
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.Dto;

public class TransferOperationInsertDto{

    public ICollection<RecipientTransferInsertDto>? RecipientTransfers{get;set;}

    public string? TruckNumber {get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ExitStockWeight{get;set;}

}