
using System.Linq;
using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Repository;

public class WarehouseRepository: RepositoryBase<Warehouse>,IWarehouseRepository{

   
    public readonly IQueryRepositoryManager _queryRepositoryManager;

    public WarehouseRepository(RepositoryContext repositoryContext,IQueryRepositoryManager queryRepositoryManager)
        : base(repositoryContext)
    {
      _queryRepositoryManager = queryRepositoryManager;
    }


    public async Task<Warehouse?> GetAllProductStockBycategory(Guid warehouseId, Category category,bool trackChange) => await
        repositoryContext.Warehouses!
        .Where(x=>x.Id.Equals(warehouseId))
        .Include(x=>x.Stocks!.Where(x=>x.product!.category.Equals(category)))!
        .ThenInclude(x=>x.product)
        .FirstOrDefaultAsync();


    public async Task<IEnumerable<Warehouse>> GetAllWarehouse(WarehouseType warehouseType,bool trackChange) => await
        FindByCondition(x=>x.WarehouseType.Equals(warehouseType),trackChange).ToListAsync();

    public async Task<Warehouse?> GetWarehouseById(Guid id,bool trackChange) =>
        //await FindByCondition(x=>x.Id.Equals(id),trackChange).FirstOrDefaultAsync();
        //await repositoryContext.Warehouses.FirstAsync(x=>x.Id.Equals(id));
        await repositoryContext.Warehouses!.FindAsync(id);

    public async Task<Warehouse?> GetWarehouseByName(string warehouseName,bool trackChange) => await 
       FindByCondition(x=>x.Name!.Equals(warehouseName),trackChange).FirstOrDefaultAsync();

    // public async Task<Warehouse?> GetWarehouseProductStock(Guid warehouseId, Guid productId,bool trackChange) => await
    //    FindByConditionWithInclude(x=>x.Id.Equals(warehouseId),trackChange,x=>x.Stocks!.Where(x=>x.productId.Equals(productId))).FirstOrDefaultAsync();

    public async Task<bool> VerifyIfProductExistInSiteById(Guid warehouseId, Guid productId) => await
       FindByCondition(x=>x.Id.Equals(warehouseId) & x.Stocks!.Any(x=>x.productId!.Equals(productId)),false).AnyAsync();

    public async Task<bool> VerifyIfProductExistInSiteByName(Guid WarehouseId, string name) => await
       FindByCondition(x=>x.Id.Equals(WarehouseId) & x.Stocks!.Any(x=>x.product!.Name!.Equals(name)),false).AnyAsync();

    public async Task<PagedList<Transfer>> GetAllTransfers(Guid WarehouseId,TransferParameters transferParameters,bool trackChange)
    {

        var filteredTransfers = _queryRepositoryManager.transfer.TransferFilterQuery(transferParameters);

         var transfers = await this.repositoryContext.Warehouses!
               .Where(x=>x.Id.Equals(WarehouseId))

               .SelectMany(x => x.transfers!)
               .Where(t => filteredTransfers.Contains(t))

               .Include(x=>x.Product)

               .Include(x=>x.Recipients)!
               .ThenInclude(x=>x.Recipient)

               .OrderByDescending(x=>x.DeliveryDate)

               .Skip((transferParameters.PageNumber - 1) * transferParameters.PageSize)
               .Take(transferParameters.PageSize)

               .ToListAsync();

         var count = await this.repositoryContext.Warehouses!
               .Where(x=>x.Id.Equals(WarehouseId))
               .Include(x=>x.transfers)!
               .SelectMany(x => x.transfers!).Where(t => filteredTransfers.Contains(t)).CountAsync(); 

        return new PagedList<Transfer>(transfers,count,transferParameters.PageNumber,transferParameters.PageSize);
    }



   public async Task<PagedList<Transfer>> GetAllDeliveries(Guid WarehouseId,TransferParameters transferParameters,bool trackChange)
   {

        var filteredTransfers = _queryRepositoryManager.transfer.TransferFilterQuery(transferParameters);

        var deliveries = await this.repositoryContext.Warehouses!

        .Where(x => x.Id.Equals(WarehouseId))
            .Include(x => x.deliveries)!
            .ThenInclude(d => d.Transfer)
            .ThenInclude(t => t!.Sender)

            .Include(x => x.deliveries)!
            .ThenInclude(d => d.Transfer)
            .ThenInclude(t => t!.Product)

            .SelectMany(x => x.deliveries!.Select(d => d.Transfer)) 
            .Where(t => filteredTransfers.Contains(t))

            .OrderByDescending(x=>x!.DeliveryDate)

            .Skip((transferParameters.PageNumber - 1) * transferParameters.PageSize)
            .Take(transferParameters.PageSize)

            .ToListAsync();


        var count = await this.repositoryContext.Warehouses!
           .Where(x => x.Id.Equals(WarehouseId))
           .Include(x => x.deliveries)!
           .ThenInclude(d => d.Transfer)
           .SelectMany(x => x.deliveries!.Select(d => d.Transfer)) 
           .Where(t => filteredTransfers.Contains(t))
           .CountAsync();

     return new PagedList<Transfer>(deliveries!,count,transferParameters.PageNumber,transferParameters.PageSize);

   }



public async Task<ICollection<WarehouseRegionDto>> GetAllWarehouseByRegion()
{
    var warehouseRegionDtos = await FindAll(false)
        .Where(x=>x.WarehouseRegion != null)
        .GroupBy(x => x.WarehouseRegion)
        .Select(group => new WarehouseRegionDto
        {
            WarehouseRegion = group.Key,
            WarehouseInfo = group.Select(warehouse => new WarehouseInfoDto
            {
                Id = warehouse.Id,
                Name=warehouse.Name,
                WarehouseType = warehouse.WarehouseType
            }).ToList()
        })
        .ToListAsync();

    return warehouseRegionDtos;
}

    // public async Task<Stock?> GetStockByProductId(Guid WarehouseId, Guid ProductId,bool trackChange) =>  await
    //     this.repositoryContext.Stocks!.Where(x=>x.warehouseId.Equals(WarehouseId) && x.productId.Equals(ProductId)).FirstOrDefaultAsync();

    // public Task<Stock> GetTrackedStockByProductId(Guid WarehouseId, Guid ProductId) {

    //    if(! this.repositoryContext.Stocks!.Local.Any(x=>x.warehouseId.Equals(WarehouseId) && x.productId.Equals(ProductId)))
    //    {
    //         return  this.repositoryContext.Stocks.FirstOrDefaultAsync(x=>x.warehouseId.Equals(WarehouseId) && x.productId.Equals(ProductId))!;
    //    }else{

    //        var result =  this.repositoryContext.ChangeTracker.Entries<Stock>()
    //            .FirstOrDefault(entry=>entry.Entity.warehouseId.Equals(WarehouseId) && entry.Entity.productId.Equals(ProductId))!
    //            .Entity;

    //          return Task.FromResult(result);
    //    }


    // }

    public async Task<Stock?> GetStockByProductId(Guid WarehouseId, Guid ProductId)
    {
        var cachedStock = this.repositoryContext.Stocks!.Local.FirstOrDefault(x =>
            x.warehouseId.Equals(WarehouseId) && x.productId.Equals(ProductId));

        if (cachedStock != null)
        {
            return cachedStock;
        }
        else
        {
            return await this.repositoryContext.Stocks
                .FirstOrDefaultAsync(x => x.warehouseId.Equals(WarehouseId) && x.productId.Equals(ProductId));
        }

    }

    public async Task<ICollection<TransferHistory>> GetTransferHistories(Guid WarehouseId) => await
        FindByCondition(x=>x.Id.Equals(WarehouseId),false).Include(x=>x.TransferHistory).SelectMany(x=>x.TransferHistory!).ToListAsync();



    public async Task<PagedList<StockChangeHistory>> getStockChangeHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var stockHistoryChange = await this.repositoryContext.StockChangeHistories
            .Where(x => x.warehouseId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category))
            .OrderByDescending(x=>x.UpdatedDate)
            .Skip((parameter.PageNumber - 1) * parameter.PageSize)
            .Take(parameter.PageSize)
            .ToListAsync();

        var count = await this.repositoryContext.StockChangeHistories.Where(x => x.warehouseId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category)).CountAsync();

        return new PagedList<StockChangeHistory>(stockHistoryChange, count, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<PagedList<TransferHistory>> TransferHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var transferHistory = await this.repositoryContext.TransferHistories!
            .Where(x=>x.SenderId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category))
            .OrderByDescending(x=>x.UpdateDate)
            .Skip((parameter.PageNumber - 1) * parameter.PageSize)
            .Take(parameter.PageSize)
            .ToListAsync();

        var count = await this.repositoryContext.TransferHistories!.Where(x => x.SenderId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category)).CountAsync();

        return new PagedList<TransferHistory>(transferHistory, count, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<PagedList<TransferHistory>> DeliveryHistory(Guid WarehouseId, HistoryParameters parameter)
    {
        var transferHistory = await this.repositoryContext.TransferHistories!
            .Where(x => x.RecipientId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category))
            .OrderByDescending(x => x.UpdateDate)
            .Skip((parameter.PageNumber - 1) * parameter.PageSize)
            .Take(parameter.PageSize)
            .ToListAsync();

        var count = await this.repositoryContext.TransferHistories!.Where(x => x.SenderId.Equals(WarehouseId) && x.ProductCategory.Equals(parameter.category)).CountAsync();

        return new PagedList<TransferHistory>(transferHistory, count, parameter.PageNumber, parameter.PageSize);
    }

}