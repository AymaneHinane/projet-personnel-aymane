



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Project.Entities.Models;



public enum WarehouseType{
    site,distributionCenter
}

public enum WarehouseRegion{
    SUNABEL_GHARB,
    SUNABEL_LOUKKOS,
    SURAC_GHARB,
    SURAC_CANNE,
    SUTA,
    ZAIO,
    SIDI_BENNOUR
}

public class Warehouse{

    public Guid Id {get;set;}

    [Required(ErrorMessage = "Warehouse name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Warehouse Name is 20 characters.")]
    public string? Name {get;set;}
    
    [IgnoreDataMember]
    public ICollection<Stock>? Stocks {get;set;}

    [NotMapped]
    public WarehouseType WarehouseType{get;set;}

    public WarehouseRegion? WarehouseRegion {get;set;}

    [IgnoreDataMember]
    public ICollection<Transfer>? transfers{get;set;}


    [IgnoreDataMember]
    public ICollection<Recipients>? deliveries {get;set;}

    public ICollection<TransferHistory>? TransferHistory{get;set;}

    public ICollection<TransferHistory>? DeliveryHistory{get;set;}

    public ICollection<StockChangeHistory>? stockChangeHistories { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }


}


