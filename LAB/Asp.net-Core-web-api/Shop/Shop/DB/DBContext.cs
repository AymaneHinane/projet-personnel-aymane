using System;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.DB
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> option) : base(option)
		{
		}

		public DbSet<ClientModel>? client { get; set; }
		public DbSet<AddressModel>? adresse { get; set; }
		public DbSet<Commande>? commande { get; set; }
		public DbSet<Product>? product { get; set; } 
		public DbSet<CommandeProduct>? CommandeProduct { get; set; }
		//public DbSet<>  { get;set;}



}
}

