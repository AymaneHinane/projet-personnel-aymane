


using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Service.Contracts.security;
using Project.Shared.Dto;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;


namespace Project.Presentation;

[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/{controller}")]
public class WarehouseController:ControllerBase{

       private IInventoryServiceManager _inventoryServiceManager;

       public WarehouseController(IInventoryServiceManager inventoryServiceManager)
       {
         _inventoryServiceManager = inventoryServiceManager;
       }

       [HttpGet("category/{warehouseType}")]
       public async Task<IActionResult> GetAllWarehouse(WarehouseType warehouseType)
       {   
          var data = await _inventoryServiceManager.warehouseService.GetAllWarehouse(warehouseType);

          return Ok(data);
       }

        [HttpGet("{warehouseId}")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> GetWarehouseById([FromRoute] Guid warehouseId)
        {
            var data = await _inventoryServiceManager.warehouseService.GetWarehouseById(warehouseId);

            return Ok(data);
        }


        [HttpGet("regions")]
        public async Task<IActionResult> GetAllWarehouseByRegion() => 
               Ok(await _inventoryServiceManager.warehouseService.GetAllWarehouseByRegion());


         [HttpPost("{warehouseId}/product/add")]
         [Authorize(Policy = "WarehousePolicy")]
         public async Task<IActionResult>  AddNewProduct([FromRoute] Guid warehouseId, [FromBody] ProductInsertDto productInsertDto)
         {
              await _inventoryServiceManager.warehouseService.AddNewProduct(warehouseId, productInsertDto);

              return Ok();
         }


        [HttpGet("{warehouseId}/category/{category}")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> GetAllProductBycategory([FromRoute]Guid warehouseId, [FromRoute]Category category){
      
              var data = await _inventoryServiceManager.warehouseService.GetAllProductStockBycategory(warehouseId, category);

              return Ok(data);
        }


        [HttpGet("{warehouseId}/initialize")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> InitializeRawMaterialStock([FromRoute]Guid warehouseId)
        {
            await _inventoryServiceManager.warehouseService.InitializeRawMaterialStock(warehouseId);

            return Ok();
        }

        [HttpGet("{warehouseId}/initializeNewYear")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> InitializeRawMaterialStockNewYear(Guid warehouseId)
        {

           await _inventoryServiceManager.warehouseService.InitializeRawMaterialStockNewYear(warehouseId);

           return Ok();
        }
     
        [HttpPost("{warehouseId}/category/{category}/product/{idP}")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> UpdateStock([FromRoute]Guid warehouseId, [FromRoute]Guid idP,[FromRoute]Category category,[FromBody] ProductUpdateDto productUpdateDto)
        {
            // if(!ModelState.IsValid)
            //    return BadRequest("the stock should be greater than 0");
       
            await _inventoryServiceManager.warehouseService.UpdateStock(warehouseId, idP,category,productUpdateDto);

            return Ok();
        }




        // [HttpGet("name/{name}")]
        // public async Task<IActionResult> GetWarehouseByName([FromRoute] string name)
        // {
        //     var data  = await _inventoryServiceManager.warehouseService.GetWarehouseByName(name);

        //     return Ok(data);
        // }


       [HttpGet("{warehouseId}/transfers")]
       [Authorize(Policy = "WarehousePolicy")]
       public async Task<IActionResult> GetAllTransfers([FromRoute] Guid warehouseId, [FromQuery] TransferParameters transferParameters)
       {
            var pagedResult =  await _inventoryServiceManager.warehouseService.GetAllTransfers(warehouseId, transferParameters);

             Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
    
            return Ok(pagedResult.transfers);
        }




       [HttpGet("{warehouseId}/deliveries")]
       [Authorize(Policy = "WarehousePolicy")]
       public async Task<IActionResult> GetAllDeliveries([FromRoute] Guid warehouseId, [FromQuery] TransferParameters transferParameters)
       {

            var pagedResult =  await _inventoryServiceManager.warehouseService.GetAllDeliveries(warehouseId, transferParameters);

             Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
    
            return Ok(pagedResult.deliveries);
        }


        //[HttpGet("{id}/transferhistory")]
        //public async Task<IActionResult> GetTransferHistories(Guid id){
        //    return Ok(await _inventoryServiceManager.warehouseService.GetTransferHistories(id));
        //}

        [HttpGet("{warehouseId}/stockChangeHistory")]
        [Authorize(Policy = "WarehousePolicy")]
        public async Task<IActionResult> GetStockChangeHistory([FromRoute] Guid warehouseId, [FromQuery] HistoryParameters parameters)
        {
            var pagedResult = await _inventoryServiceManager.warehouseService.getStockChangeHistory(warehouseId, parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.histories);
        }


         [HttpGet("{warehouseId}/transferHistory")]
         [Authorize(Policy = "WarehousePolicy")]
         public async Task<IActionResult> GetTransferHistory([FromRoute] Guid warehouseId, [FromQuery] HistoryParameters parameters)
         {
                var pagedResult = await _inventoryServiceManager.warehouseService.TransferHistory(warehouseId, parameters);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

                return Ok(pagedResult.histories);
         }

         [HttpGet("{warehouseId}/deliveryHistory")]
         [Authorize(Policy = "WarehousePolicy")]
         public async Task<IActionResult> GetDeliveryHistory([FromRoute] Guid warehouseId, [FromQuery] HistoryParameters parameters)
         {
                var pagedResult = await _inventoryServiceManager.warehouseService.DeliveryHistory(warehouseId, parameters);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

                return Ok(pagedResult.histories);
         }


         [HttpGet("{warehouseId}/finishedProduct/excel")]
         [Authorize(Policy = "WarehousePolicy")]
         public async Task<IActionResult> DownloadExcel([FromRoute] Guid warehouseId)
         {
           var excelData = await _inventoryServiceManager.warehouseService.DownloadFinishedProductExcel(warehouseId); // Replace with your data retrieval method

           return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StockData.xlsx");
         }


}


