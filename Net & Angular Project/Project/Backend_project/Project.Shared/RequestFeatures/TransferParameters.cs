
using Project.Entities.Models;

namespace Project.Shared.Request;


public class TransferParameters:RequestParameters{

    const int maxPageSize = 50;
    public int PageNumber {get;set;} = 1;
    private int _pageSize = 15;
    public int PageSize 
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }


    public int? numero {get;set;} = null;
    public string? sender {get;set;} = null;
    public string? recipient {get;set;} = null;
    public TransferStatus? status {get;set;} = null;
    public WarehouseType? recipientType {get;set;} = null;
    public WarehouseRegion? region {get;set;} = null;
    public string? product {get;set;} = null;
    public decimal? qte {get;set;} = null;
    public DateTime? deliveryDate {get;set;} = null;
    public DateTime? shippedDate {get;set;} = null;
    
}