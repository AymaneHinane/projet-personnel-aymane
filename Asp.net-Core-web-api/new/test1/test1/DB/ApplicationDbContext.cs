using System;
using Microsoft.EntityFrameworkCore;

using test1.Model.Shema2;

namespace test1.DB
{
	public class ApplicationDbContext:DbContext
	{


		public DbSet<Review> Reviews;
        public DbSet<Author> Authors;
        public DbSet<Book> Books;
        public DbSet<Category> Categories;
        public DbSet<PriceOffers> PriceOffers;
        public DbSet<Order> Orders;
        public DbSet<Customer> Customers;



		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{



		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (entityProperty.ClrType == typeof(decimal) && entityProperty.Name.Contains("Price"))
                    {
                        entityProperty.SetPrecision(9);
                        entityProperty.SetScale(2);
                    }
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreateDate")
                    .HasDefaultValue(DateTime.Now);

                modelBuilder.Entity(entityType.ClrType)
                   .Property<DateTime?>("UpdateDate")
                   .HasDefaultValue((DateTime?)null);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



        }
    }
}

