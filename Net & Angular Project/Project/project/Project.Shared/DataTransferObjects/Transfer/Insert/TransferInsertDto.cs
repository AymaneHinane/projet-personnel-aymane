
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Entities.Models;

namespace Project.Shared.Dto;



public class TransferInsertDto{

    public Guid SenderId{get;set;}

    public ICollection<RecipientInsertDto>? Recipients {get;set;}

    public Guid ProductId{get;set;}


    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TransferedStockQuantity{get;set;} 

    public WarehouseType DestinationType {get;set;}
    
}