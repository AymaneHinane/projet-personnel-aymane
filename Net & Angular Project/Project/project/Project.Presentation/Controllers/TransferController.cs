
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;
using Project.Shared.Request;

namespace Project.Presentation;

[ApiController]
[Route("api/{controller}")]
public class TransferController:ControllerBase{

   private ITransferServiceManager _service;

   public TransferController(ITransferServiceManager transferServiceManager) => _service = transferServiceManager;


   [HttpGet("{id}")]
   public async Task<IActionResult> TransferOverviewById(Guid id){

      var data = await _service.transferService.TransferOverviewById(id);

      return Ok(data); 
   }


   [HttpPost]
   public async Task<IActionResult>  TransferInsert(TransferInsertDto transferDto){

        if(!ModelState.IsValid)
           return BadRequest(ModelState);

        await _service.transferService.TransferInsert(transferDto);

        return Ok();
   }

   [HttpPost("{id}/delivery")]
   public async Task<IActionResult> AddNewDelivery([FromRoute] Guid id,[FromBody] TransferOperationInsertDto transferOperationInsertDto){

        if(!ModelState.IsValid)
           return BadRequest(ModelState);

        await _service.transferService.AddNewDelivery(id,transferOperationInsertDto);

        return Ok();
   }

   [HttpGet("{id}/recipients")]
   public async Task<IActionResult> GetRecipientsByTransferId([FromRoute]Guid id){

      var data = await _service.transferService.GetRecipientsByTransferId(id);

      return Ok(data); 
   }


   [HttpGet("{id}/transferoperation")]
   public async Task<IActionResult> GetTransferOperationByTransferId([FromRoute]Guid id){

      var data = await _service.transferService.GetTransferOperationByTransferId(id);

      return Ok(data);
   }


    [HttpPut("{id}")]
    public  async Task<IActionResult> UpdateTransfer([FromRoute] Guid id,[FromBody] TransferUpdateDto transferUpdate)
    {
        await _service.transferService.UpdateTransfer(id, transferUpdate);

        return Ok();
    }





} 