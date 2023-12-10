
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Contracts;
using Project.Shared;
using Project.Shared.Dto;

namespace Project.Presentation;



[ApiController]
[Route("api/{controller}")]
public  class TransferOperationController:ControllerBase{

    private ITransferServiceManager _service;

    public TransferOperationController(ITransferServiceManager transferServiceManager) => _service = transferServiceManager;

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransferOperation([FromRoute]Guid Id,[FromBody]TransferOperationUpdateDto transferOperationUpdateDto){

        if (!ModelState.IsValid)
           return BadRequest(ModelState);

        await _service.transferOperationService.UpdateTransferOperation(Id,transferOperationUpdateDto);

        return Ok();
    }


    [HttpPut("{id}/recipient")]
    public async Task<IActionResult> UpdateRecipientTransfer([FromRoute]Guid id,[FromBody] ICollection<RecipientTransferUpdateDto> recipientsTransferUpdateDtos){

        if (!ModelState.IsValid)
           return BadRequest(ModelState);

        await _service.transferOperationService.UpdateRecipientTransfer(id,recipientsTransferUpdateDtos);

        return Ok(); 
    }

    [HttpPost("{id}/voucher/{type}")]
    public async Task<IActionResult> AddNewTransferOperationVoucher([FromRoute]Guid id,[FromRoute] voucherType type,IFormFile file){
         
         if( file == null || file.Length == 0 )
           return BadRequest("No file uploaded");

          using(var ms = new MemoryStream())
          {
            await file.CopyToAsync(ms);
            byte[] fileBytes = ms.ToArray();

            await _service.transferOperationService.AddVoucher(id,type,fileBytes);
          }

         return Ok("File uploaded successfully");
    }


    [HttpGet("{id}/voucher/{type}")]
    public async Task<IActionResult> GetVoucher([FromRoute]Guid id,[FromRoute] voucherType type){
         
        byte[] voucher = await _service.transferOperationService.GetVoucher(id,type);
        string filename = $"{type.ToString().ToLower()}_voucher.pdf";

         return File(voucher, "application/pdf", filename);
    }

}