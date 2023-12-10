

using System.ComponentModel.DataAnnotations;
using Project.Entities.Models;

namespace Project.Shared.Dto;

public class WarehouseStockInfoDto{
     
    public Guid Id;
    [Required(ErrorMessage = "Warehouse name is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Warehouse Name is 20 characters.")]
    public string? Name;

    public Category category;
}