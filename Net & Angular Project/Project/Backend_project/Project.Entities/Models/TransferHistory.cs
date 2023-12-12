
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Entities.Models;

public enum TransferHistoryType{
     transfer,
     delivery
}

public class TransferHistory{

    public Guid Id{get;set;}
    public string? EditedField{get;set;}
    public DateTime? UpdateDate{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OldValue{get;set;}

    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NewValue{get;set;}

    public Guid? TransferId{get;set;}
    public Transfer? Transfer{get;set;}
    public int TranferNumero { get; set; }

    public Guid SenderId{get;set;}
    public Warehouse? Sender{get;set;}
    public string? SenderName{get;set;}

    public Guid? RecipientId{get;set;}
    public Warehouse? Recipient{get;set;}
    public string? RecipientName{get;set;}

    public Guid ProductId{get;set;}
    public Product? Product{get;set;}
    public string? ProductName{get;set;}    

    public Category? ProductCategory{get;set;} 

    TransferHistoryType?  TransferHistoryType{get;set;}
}