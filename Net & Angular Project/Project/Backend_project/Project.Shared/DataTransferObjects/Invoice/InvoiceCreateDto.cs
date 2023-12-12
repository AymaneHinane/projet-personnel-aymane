using System;
using Project.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Project.Shared.DataTransferObjects.Invoice
{
	public class InvoiceCreateDto
	{

        public string? InvoiceNumber { get; set; }

       
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Excl_taxes { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Incl_taxes { get; set; }

        public IFormFile? InvoicePdf { get; set; }
        //public byte[]? InvoicePdf { get; set; }

        public Guid InvoiceCategoryId { get; set; }

        public Guid WarehouseId { get; set; }

    }
}

