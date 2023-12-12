using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Contracts;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.RequestFeatures;

namespace Project.Presentation.Controllers
{
	[ApiController]
	[Route("api/{controller}")]
	public class ChargeController: ControllerBase
	{
		private readonly IChargeServiceManager _chargeServiceManager;


        public ChargeController(IChargeServiceManager chargeServiceManager )
		{
			_chargeServiceManager = chargeServiceManager;
		}

		[HttpGet("invoices/{warehouseId}")]
        [Authorize(Policy = "WarehousePolicy")]
        public  async Task<IActionResult> getInvoices([FromRoute] Guid warehouseId, [FromQuery] InvoiceParameters parameters)
		{
			var pagedResult = await _chargeServiceManager.InvoiceService.getAllInvoicesByWarehouseId(warehouseId, parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.invoices);
        }

		[HttpGet("invoiceCategory")]
		public async Task<IActionResult> getAllCategory()
		{
			return Ok(await _chargeServiceManager.InvoiceCategoryService.getAllCategory());
		}

        [HttpPost("invoice")]
		public async Task<IActionResult> addNewInvoice([FromForm] InvoiceCreateDto invoiceCreateDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _chargeServiceManager.InvoiceService.addNewInvoice(invoiceCreateDto);

			return Ok("ok");
		}


		[HttpGet("invoice/{id}/pdf")]
		public async Task<IActionResult> getInvoicePdf([FromRoute]Guid id)
		{
			//return Ok(await _chargeServiceManager.InvoiceService.getInvoicePdf(id));

			var data = await _chargeServiceManager.InvoiceService.getInvoicePdf(id);
			byte[] pdf = data.InvoicePdf;

            return File(pdf, "application/octet-stream", "example.pdf");

        }




    }
}

