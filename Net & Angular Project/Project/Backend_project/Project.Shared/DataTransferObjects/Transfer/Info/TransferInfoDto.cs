

using Project.Entities.Models;

namespace Project.Shared.Dto;


public class TransferInfoDto{
    public Guid Id{get;set;}
    public int Numero{get;set;}
    
    public DestinationInfoDto? Sender {get;set;}

    public ProductInfoDto? Product{get;set;}
    
    public ICollection<DestinationInfoDto>? Recipients{get;set;}

    public decimal transferedStockQuantity {get;set;}
    public TransferStatus transferStatus {get;set;}
    public DateTime deliveryDate {get;set;}
    public DateTime? shippedDate {get;set;} = null;

}