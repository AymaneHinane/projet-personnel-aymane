using System;
using Microsoft.EntityFrameworkCore;
using test3.Models;

namespace test3.DB
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{

		}

		#region Required
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
		#endregion

		public DbSet<Pharmacie> pharmacies { get; set; }
		public DbSet<Medicament> medicaments { get; set; }

	}
}

