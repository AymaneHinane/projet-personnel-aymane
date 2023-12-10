using System;
using Project.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shared.DataTransferObjects.Invoice
{
	public class InvoiceInfoDto
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

        //public byte[]? InvoicePdf { get; set; }
        public bool InvoiceExist { get; set; }

        public string? Category { get; set; }

    }
}

