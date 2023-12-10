using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore;

namespace Project.Entities.Models
{
	public class Invoice
	{
        public Guid Id { get; set; }
        public string? InvoiceNumber { get; set; }

        public DateTime date { get; set; } = DateTime.UtcNow;

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Excl_taxes { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Incl_taxes { get; set; }

        public byte[]? InvoicePdf { get; set; } = null;

        public Guid InvoiceCategoryId { get; set; }
        public InvoiceCategory? InvoiceCategory { get; set; }

        public Guid WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}

