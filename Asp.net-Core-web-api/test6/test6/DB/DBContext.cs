using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test6.Models;
using test6.Models.ProductDescription;

namespace test6.DB
{
	public class DBContext:DbContext
	{

		public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);

			



        }


	
		public DbSet<Client> Clients => Set<Client>();
		public DbSet<Order> Orders => Set<Order>();
		public DbSet<Address> Addresses => Set<Address>();
		public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
		public DbSet<Product> Products => Set<Product>();
		public DbSet<Store> Stores => Set<Store>();
		public DbSet<Employee> Employees => Set<Employee>();
		public DbSet<Car> Cars => Set<Car>();
		public DbSet<Clothes> Clothes => Set<Clothes>();
		public DbSet<Electronics> Electronics => Set<Electronics>();
		public DbSet<Book> Books => Set<Book>();
		

	}
}

