

using AutoMapper;
using MediatR;
using OfficeOpenXml;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Entities.Exceptions;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Service;

public class WarehouseService:IWarehouseService{

    private readonly IInventoryRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;

    private readonly IMediator _mediator;

  
    public WarehouseService(IInventoryRepositoryManager repository, ILoggerManager logger,IMapper mapper,IMediator mediator)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }

 

    public async Task AddNewProduct(Guid warehouseId, ProductInsertDto productInsertDto)
    {

         var ProductExist = await _repository.Warehouse.VerifyIfProductExistInSiteByName(warehouseId,productInsertDto.name!);

         if(ProductExist)
            throw new BadRequestException("the product already exist in this warehouse");

        var warehouse = await _repository.Warehouse.GetWarehouseById(warehouseId,true);

        if(warehouse is null)
            throw new NotFoundException($"the warehouse with id {warehouseId} was not found");

         var product =  new Product(){Name=productInsertDto.name,category=productInsertDto.category};

        _repository.Product.AddNewProduct(product);

        warehouse.Stocks = new List<Stock>(){
             new Stock(){product=product}
        };

        await _repository.SaveAsync();
    }

    public async Task InitializeRawMaterialStock(Guid warehouseId)
    {
        var products = await _repository.Product.GetAllProductAsync(Category.rawMaterial,false);

        var warehouse = await _repository.Warehouse.GetWarehouseById(warehouseId,true);

        if(warehouse is null)
            throw new NotFoundException($"the warehouse with id {warehouseId} was not found");

        warehouse.Stocks = new List<Stock>();

        foreach(var product in products)
        {
             warehouse.Stocks.Add(new Stock(){product=product});
        }

        await _repository.SaveAsync();

    }


    public async Task InitializeRawMaterialStockNewYear(Guid warehouseId)
    {
        var warehouse = await _repository.Warehouse.GetAllProductStockBycategory(warehouseId, Category.rawMaterial, true);

        foreach(var stock in warehouse.Stocks)
        {
            stock.OrderStock = 0;
            stock.DeliverStock = 0;
            stock.ConsumeStock = 0;
            stock.DAPStock = 0;
            stock.TransferedStockExitTotal = 0;
            stock.TransferedStockEntryTotal = 0;
            stock.LastYearRemainingStock = stock.RemainingStock;
            stock.RemainingStock = 0;
        }

        await this._repository.SaveAsync();

    }

    public async Task<IEnumerable<WarehouseInfoDto>> GetAllWarehouse(WarehouseType warehouseType) {
        var warehouses =  await _repository.Warehouse.GetAllWarehouse(warehouseType,false);

        return _mapper.Map<IEnumerable<WarehouseInfoDto>>(warehouses);
    }

    public async Task<WarehouseInfoDto?> GetWarehouseById(Guid id)
    {
       var warehouse  = await _repository.Warehouse.GetWarehouseById(id,false);

       return _mapper.Map<WarehouseInfoDto>(warehouse);
    }


    public async Task<WarehouseInfoDto?> GetWarehouseByName(string warehouseName)
    {
       var warehouse  = await _repository.Warehouse.GetWarehouseByName(warehouseName,false);

       if(warehouse == null)
          throw new NotFoundException("this warehouse was not founded"); 

        return _mapper.Map<WarehouseInfoDto>(warehouse);
    }

    public async Task UpdateStock(Guid warehouseId, Guid productId,Category category, ProductUpdateDto productUpdateDto)
    {
    //    var IfProductExistInWarehouse =await _repository.Warehouse.VerifyIfProductExistInSiteById(warehouseId,productId);

    //    if(!IfProductExistInWarehouse)
    //        throw new NotFoundException("stock not found");

       var stock = await _repository.Warehouse.GetStockByProductId(warehouseId,productId);

       
       _mapper.Map(productUpdateDto,stock);

       if(Category.rawMaterial.Equals(category))
       {
         stock!.DAPStock = stock.DeliverStock + stock.LastYearRemainingStock;  
         stock.RemainingStock = stock.DeliverStock - stock.ConsumeStock - stock.TransferedStockExitTotal + stock.TransferedStockEntryTotal;

       }else if(Category.finishedProduct.Equals(category)){
         stock!.RemainingStock = stock.StockProduced - stock.TransferedStockExitTotal;
       }

        if (stock!.RemainingStock < 0)
        {
            throw new MethodNotAllowed("stock insuffisant");
        }


       await _repository.SaveAsync();
    }

    public async Task<WarehouseStockInfoDto?> GetAllProductStockBycategory(Guid warehouseId, Category category)
    {

       var data  = await _repository.Warehouse.GetAllProductStockBycategory(warehouseId,category,false);

        if(data is null)
            throw new NotFoundException("not product has been found");

        if (data.Stocks!.Count() == 0)
            throw new NotFoundException("stock not found");

        if(Category.finishedProduct.Equals(category))
            return _mapper.Map<WarehouseFinishedProductStockDto>(data);
         else if(Category.rawMaterial.Equals(category))
             return _mapper.Map<WarehouseRawMaterilaStockDto>(data);

         return null;
          
    }

    public async Task verifyIfWarehouseExist(Guid warehouseId)
    {
        var warehouse = await _repository.Warehouse.GetWarehouseById(warehouseId,true);

        if(warehouse is null)
            throw new NotFoundException($"the warehouse with id {warehouseId} was not found");
    }

    public async Task verifyIfProductExistInWarehouse(Guid warehouseId,Guid productId)
    {
       var IfProductExistInWarehouse =await _repository.Warehouse.VerifyIfProductExistInSiteById(warehouseId,productId);

       if(!IfProductExistInWarehouse)
           throw new NotFoundException("stock not found");
    }

    public async  Task<(ICollection<TransferInfoDto> transfers,MetaData metaData)> GetAllTransfers(Guid WarehouseId,TransferParameters transferParameters)
    {
        var transfers  = await this._repository.Warehouse.GetAllTransfers(WarehouseId,transferParameters,false);

        var transfersDto = _mapper.Map<ICollection<TransferInfoDto>>(transfers);

        return (transfers:transfersDto,metaData:transfers.MetaData);
    } 


    public async Task<(ICollection<TransferInfoDto>deliveries,MetaData metaData)> GetAllDeliveries(Guid WarehouseId,TransferParameters transferParameters) 
    { 
       var deliveries  = await this._repository.Warehouse.GetAllDeliveries(WarehouseId,transferParameters,false);

        var deliveriesDto = _mapper.Map<ICollection<TransferInfoDto>>(deliveries);

        return (deliveries:deliveriesDto,metaData:deliveries.MetaData);
    }

    public async Task<ICollection<WarehouseRegionDto>> GetAllWarehouseByRegion() => await 
      _repository.Warehouse.GetAllWarehouseByRegion();

    //public async Task<ICollection<TransferHistory>> GetTransferHistories(Guid WarehouseId) => await
    //   this.GetTransferHistories(WarehouseId);



    public async Task<(ICollection<StockChangeHistory> histories, MetaData metaData)> getStockChangeHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var histories = await this._repository.Warehouse.getStockChangeHistory(WarehouseId, parameter);

        return (histories: histories, metaData: histories.MetaData);
    }

    public async Task<(ICollection<TransferHistory> histories, MetaData metaData)> TransferHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var histories = await this._repository.Warehouse.TransferHistory(WarehouseId, parameter);

        return (histories: histories, metaData: histories.MetaData);
    }

    public async Task<(ICollection<TransferHistory> histories, MetaData metaData)> DeliveryHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var histories = await this._repository.Warehouse.DeliveryHistory(WarehouseId, parameter);

        return (histories: histories, metaData: histories.MetaData);
    }

    public async Task<byte[]> DownloadFinishedProductExcel(Guid warehouseId)
    {
        var data = await _repository.Warehouse.GetAllProductStockBycategory(warehouseId, Category.finishedProduct, false);

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("StockData");

            // Add headers
            worksheet.Cells["A1"].Value = "Product Name";
            worksheet.Cells["B1"].Value = "Stock Produced";
            worksheet.Cells["C1"].Value = "Transferred Stock Exit Total";
            worksheet.Cells["D1"].Value = "Remaining Stock";
            worksheet.Cells["E1"].Value = "warehouse";

            int row = 2; // Start from the second row for data

            // Populate the Excel sheet with data
            foreach (var item in data.Stocks)
            {
                worksheet.Cells["A" + row].Value = item.product.Name;
                worksheet.Cells["B" + row].Value = item.StockProduced;
                worksheet.Cells["C" + row].Value = item.TransferedStockExitTotal;
                worksheet.Cells["D" + row].Value = item.RemainingStock;
                worksheet.Cells["E" + row].Value = item.warehouse.Name;
                row++;
            }

            // Convert the package to a byte array and return for download
            return package.GetAsByteArray();
        }
    }
}
