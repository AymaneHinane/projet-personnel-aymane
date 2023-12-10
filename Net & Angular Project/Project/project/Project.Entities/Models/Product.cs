


using System.ComponentModel.DataAnnotations;


namespace Project.Entities.Models;

public enum Category{
    rawMaterial,
    finishedProduct
}


public class Product{

    public Guid Id {get;set;}

    [Required(ErrorMessage = "Product name is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Product Name is 20 characters.")]
    public string? Name{get;set;}

    public Category category {get;set;}
    public ICollection<Stock>? Stocks {get;set;}

   public ICollection<TransferHistory>? TransferHistory{get;set;}
}