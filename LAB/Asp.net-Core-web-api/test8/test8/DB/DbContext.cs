using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using test8.Model;
using test8.Model.Library;
using test8.Model.Shop;

namespace test8.DB
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder model)
		{
			model.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);

			foreach (var entityType in model.Model.GetEntityTypes())
			{
				model.Entity(entityType.ClrType)
					.Property<DateTime>("CreateDate")
					.HasDefaultValue(DateTime.Now);

				model.Entity(entityType.ClrType)
				   .Property<DateTime?>("UpdateDate")
				   .HasDefaultValue((DateTime?)null);
			}

			model.Entity<Author2>().HasData(
				  new Author2 { AuthorId=1, Name="joseph", WebUrl="http//helloworld.org" },
                  new Author2 { AuthorId = 2, Name = "bahari", WebUrl = "http//bahari.com" }
                );


			model.Entity<Book>().HasData(
				  new Book {
					  BookId=1,
					  Title="Hello wolrd",
					  Description="basic of coding",
					  PublishedOn=DateTime.UtcNow.AddDays(3),
					  Price=50.00m
					  
				  },
                  new Book
                  {
                      BookId = 2,
                      Title = "foot mangering",
                      Description = "basic of footbal coathing",
                      PublishedOn = DateTime.UtcNow.AddDays(8),
                      Price = 70.00m

                  }
                );

			model.Entity<BookAuthor>().HasData(
                  new BookAuthor
				  {
					BookId=1,
					AuthorId=1
				  },
                  new BookAuthor
                  {
                     BookId = 2,
                     AuthorId = 2
                  }
                );

			model.Entity<PriceOffers>().HasData(
				  new PriceOffers
				  {
					  PriceOffersId=1,
					  NewPrice=30,
					  PromotionalText="Save 1$ if you ordered 40 unit",
					  BookId=1
				  },
                  new PriceOffers
                  {
                      PriceOffersId = 2,
                      NewPrice = 20,
                      PromotionalText = "Save 2$ if you ordered 20 unit",
					  BookId=2
                  }
                );

			model.Entity<Review>().HasData(
				  new Review
				  {
					  ReviewId=1,
					  VoterName="anayelle",
					  NumStars=5.0,
					  Comment="I Love this book a lot",
					  BookId=1
				  },
                  new Review
                  {
                      ReviewId = 2,
                      VoterName = "joelle",
                      NumStars = 3.0,
                      Comment = "I hate this book",
                      BookId = 2
                  }
                );

			model.Entity<Tags>().HasData(
				 new Tags {
					 TagsId = 1,
					 Books = new List<Book>() { new Book { BookId = 1 } }
				 },
                 new Tags {
					 TagsId = 2,
                     Books = new List<Book>() { new Book { BookId = 2 } }
                 }
                );



		}

		public DbSet<Book> Books { get; set; }

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Author> Authors { get; set; }

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ShippingAdresse> shippingAdresses { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductPropertyValue>  productPropertyValues{get;set;}
        public DbSet<ProductCategoryProperty> ProductCategoryProperty { get;set;}
		public DbSet<ProductProperty> productProperties { get; set; }

	}
}

