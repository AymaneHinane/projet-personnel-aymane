
using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Service.Contracts;



public interface IWarehouseService{


    Task<IEnumerable<WarehouseInfoDto>> GetAllWarehouse(WarehouseType warehouseTypex);
    Task<WarehouseInfoDto?> GetWarehouseById(Guid id);
    Task<WarehouseInfoDto?> GetWarehouseByName(string warehouseName);
    Task<ICollection<WarehouseRegionDto>> GetAllWarehouseByRegion();

    Task AddNewProduct(Guid warehouseId,ProductInsertDto productInsertDto);

    Task InitializeRawMaterialStock(Guid warehouseId);
    Task InitializeRawMaterialStockNewYear(Guid warehouseId);

    Task UpdateStock(Guid warehouseId,Guid productId,Category category,ProductUpdateDto productUpdateDto);

    Task<WarehouseStockInfoDto?> GetAllProductStockBycategory(Guid warehouseId, Category category);

    Task verifyIfWarehouseExist(Guid warehouseId);

    Task verifyIfProductExistInWarehouse(Guid warehouseId,Guid productId);


    Task<(ICollection<TransferInfoDto> transfers,MetaData metaData)> GetAllTransfers(Guid WarehouseId,TransferParameters transferParameters);

    Task<(ICollection<TransferInfoDto>deliveries,MetaData metaData)> GetAllDeliveries(Guid WarehouseId,TransferParameters transferParameters);


    //Task<ICollection<TransferHistory>> GetTransferHistories(Guid WarehouseId);

    Task<(ICollection<StockChangeHistory> histories, MetaData metaData)> getStockChangeHistory(Guid WarehouseId, HistoryParameters parameter);
    Task<(ICollection<TransferHistory> histories, MetaData metaData)> TransferHistory(Guid WarehouseId, HistoryParameters parameter);
    Task<(ICollection<TransferHistory> histories, MetaData metaData)> DeliveryHistory(Guid WarehouseId, HistoryParameters parameter);

    Task<byte[]> DownloadFinishedProductExcel(Guid warehouseId);
}