
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Entities.Models;
using Project.Service;
using Project.Shared.Dto;

public class ProductService:IProductService{


     private readonly IInventoryRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;

    public ProductService(IInventoryRepositoryManager repository, ILoggerManager logger,IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
       // _mediator = mediator;
    }

    public async Task<IEnumerable<Product>?> GetAllProductStockByCategory(Category category) => await
        _repository.Product.GetAllProductStockByCategory(category,false);

    public async Task<IEnumerable<Product>?> GetAllProductByWarehouseIdAndCategory(Guid Id, Category category) => await
       _repository.Product.GetAllProductByWarehouseIdAndCategory(Id,category,false);

    public async Task<IEnumerable<ProductInfoDto>> GetAllProductAsync(Category category) => 
       _mapper.Map<IEnumerable<ProductInfoDto>>( await _repository.Product.GetAllProductAsync(category,false));

    public async Task<byte[]> DownloadFinishedProductExcel()
    {
        var data = await _repository.Product.GetFinishedProductStock();

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
            foreach (var item in data)
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