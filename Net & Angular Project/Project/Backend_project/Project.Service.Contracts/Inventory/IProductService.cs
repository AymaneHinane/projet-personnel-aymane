

using Project.Entities.Models;
using Project.Shared.Dto;

namespace Project.Service;


public interface IProductService{

    Task<IEnumerable<ProductInfoDto>> GetAllProductAsync(Category category);
    Task<IEnumerable<Product>?> GetAllProductStockByCategory(Category category);
    Task<IEnumerable<Product>?> GetAllProductByWarehouseIdAndCategory(Guid Id,Category category);
    Task<byte[]> DownloadFinishedProductExcel();
}