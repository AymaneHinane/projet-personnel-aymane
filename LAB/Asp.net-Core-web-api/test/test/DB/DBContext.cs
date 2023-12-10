using System;
using Microsoft.EntityFrameworkCore;
using test.Models;
using test.ModelsSearch;

namespace test.DB
{
	public class DBContext:DbContext
	{
		public DBContext(DbContextOptions<DBContext> option):base(option)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
			//modelBuilder.Entity<User>().HasKey(u => u.Id);
			//modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(150);

			/*modelBuilder.Entity<Magasin>()
				.Property(b => b.Name)
				.HasDefaultValue("not defined");*/

			modelBuilder.Entity<Product>()
				.Property(p => p.AddDepot)
				.HasDefaultValueSql("GETDATE()");

			modelBuilder.Entity<Product>().Property(b => b.price).HasColumnType("decimal(7, 3)");

			modelBuilder.Entity<ProductCommande>()
				.Property(pc => pc.PublicationDate)
				.HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Client>()
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName]+' '+[FirstName]")
				.ValueGeneratedOnAddOrUpdate();

            /*modelBuilder.Entity<Category>()
				.Property(c => c.Id)
				.ValueGeneratedOnAdd();*/


            modelBuilder.Entity<Product>()
				.HasMany(p => p.Commandes)
				.WithMany(p => p.Products)
				.UsingEntity<ProductCommande>(
				   j => j
				   .HasOne(pc => pc.Commande)
				   .WithMany(c => c.ProductCommandes)
				   .HasForeignKey(pc => pc.CommandeId),
				   j => j
				   .HasOne(pc => pc.Product)
				   .WithMany(c => c.ProductCommandes)
				   .HasForeignKey(pc => pc.ProductId),
				   j =>
				   {
					   j.Property(pt => pt.PublicationDate).HasDefaultValueSql("GETDATE()");
					   j.HasKey(t => new { t.ProductId, t.CommandeId});
				   });


		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Magasin>? Magasins { get; set; }
		public DbSet<Employee>? Employees { get; set; }
		public DbSet<Product>? Products { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Client>? Clients { get; set; }
		public DbSet<Commande> Commandes { get; set; }
		public DbSet<ProductCommande> ProductCommandes { get; set; }
		public DbSet<CommandeDetails> commandeDetails { get; set; }

		public DbSet<User> Users => Set<User>();
	}
}

