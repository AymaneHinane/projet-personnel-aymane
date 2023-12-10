
using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Contracts;



public interface IWarehouseRepository{


    Task<IEnumerable<Warehouse>> GetAllWarehouse(WarehouseType warehouseType,bool trackChange);

    Task<Warehouse?> GetWarehouseById(Guid id,bool trackChange);
    Task<Warehouse?> GetWarehouseByName(string warehouseName,bool trackChange);

    Task<ICollection<WarehouseRegionDto>> GetAllWarehouseByRegion();

    //Task<Warehouse?> GetWarehouseProductStock(Guid warehouseId,Guid productId,bool trackChange);

    Task<Boolean> VerifyIfProductExistInSiteByName(Guid WarehouseId,string name);

    Task<Boolean> VerifyIfProductExistInSiteById(Guid warehouseId, Guid productId);

    Task<Warehouse?> GetAllProductStockBycategory(Guid warehouseId,Category category,bool trackChange);

    Task<PagedList<Transfer>> GetAllTransfers(Guid WarehouseId,TransferParameters transferParameters,bool trackChange);
    Task<PagedList<Transfer>> GetAllDeliveries(Guid WarehouseId,TransferParameters transferParameters,bool trackChange);

    Task<Stock?> GetStockByProductId(Guid WarehouseId,Guid ProductId);

    Task<ICollection<TransferHistory>> GetTransferHistories(Guid WarehouseId);

    // Task<Stock?> GetTrackedStockByProductId(Guid WarehouseId, Guid ProductId);

    Task<PagedList<StockChangeHistory>> getStockChangeHistory(Guid WarehouseId, HistoryParameters parameter);
    Task<PagedList<TransferHistory>> TransferHistory(Guid WarehouseId, HistoryParameters parameter);
    Task<PagedList<TransferHistory>> DeliveryHistory(Guid WarehouseId, HistoryParameters parameter);

}