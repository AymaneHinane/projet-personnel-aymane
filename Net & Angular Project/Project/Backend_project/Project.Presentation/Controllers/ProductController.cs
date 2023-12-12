

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.Service.Contracts;

namespace Project.Presentation;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/{controller}")]
public class ProductController:ControllerBase{



private IInventoryServiceManager _inventoryServiceManager;

public ProductController(IInventoryServiceManager inventoryServiceManager) => _inventoryServiceManager = inventoryServiceManager;


[HttpGet("{category}")]
public async Task<IActionResult> GetAllProduct([FromRoute] Category category) => 
   Ok( await _inventoryServiceManager.productService.GetAllProductAsync(category));


[HttpGet("stock/category/{category}")]
public async Task<IActionResult> GetAllProductStockByCategory([FromRoute] Category category){

     var data = await _inventoryServiceManager.productService.GetAllProductStockByCategory(category);

     return Ok(data);
}


[HttpGet("warehouse/{id}/category/{category}")]
public async Task<IActionResult> GetAllProductByCategory([FromRoute] Guid id,[FromRoute] Category category){

     var data = await _inventoryServiceManager.productService.GetAllProductByWarehouseIdAndCategory(id,category);

     return Ok(data);
}

[HttpGet("finishedProduct/excel")]
public async Task<IActionResult> DownloadExcel()
{
        var excelData = await _inventoryServiceManager.productService.DownloadFinishedProductExcel(); 

    return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StockData.xlsx");
}



}