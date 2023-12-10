using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Entities.Models
{
	public class StockChangeHistory
	{
		public Guid Id { get; set; }
		public string? PropertyNameEng { get; set; }
        public string? PropertyNameFr { get; set; }
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OldValue { get; set; }
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? NewValue { get; set; }
		public string? ProductName { get; set; }
		public Category ProductCategory { get; set; }
		public Guid warehouseId { get; set; }
		public Warehouse? warehouse { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}


