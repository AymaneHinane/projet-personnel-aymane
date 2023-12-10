using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using test8.Model.Library;
using tp9.Library;

namespace test8.DB
{
	public class DBContext : DbContext
	{

        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookAuthor> bookAuthors { get; set; }
        public DbSet<ConcurrencyBook> concurrencyBooks { get; set; }
        public DbSet<ConcurrencyAuthor> concurrencyAuthors { get; set; }



        public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}


     


        protected override void OnModelCreating(ModelBuilder model)
		{
			//model.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);

			model.Entity<BookAuthor>().HasKey(x=>new {x.AuthorId,x.BookId });

			model.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            model.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            model.Entity<Books>().HasOne(b => b.Promotion).WithOne(p => p.Book).HasForeignKey<PriceOffers>(p => p.BookId);
			model.Entity<Books>().HasMany(b => b.Tags).WithMany(t => t.Books);
			//model.Entity("BooksTags").HasKey("BooksBookId", "TagsId");
			model.Entity<Books>().HasKey(b => b.BookId);

            //context.Books.IgnoreQueryFilters(). 
           // model.Entity<Books>().HasQueryFilter(p => !p.SoftDeleted);

            model.Entity<Customer>().HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);


            model.Entity<LineItem>().HasKey(x => new { x.BookId, x.OrderId });
           // model.Entity<LineItem>().HasNoKey();
            model.Entity<LineItem>().HasOne(li => li.Book).WithMany(b => b.lineItems).HasForeignKey(li => li.BookId);
            model.Entity<LineItem>().HasOne(li => li.Order).WithMany(o => o.lineItems).HasForeignKey(li => li.OrderId);

            model.Entity<Books>().HasKey(b => b.BookId);
            model.Entity<Review>().HasKey(r => r.ReviewId);
            model.Entity<Books>().HasMany(b => b.Reviews).WithOne(r => r.Book).HasForeignKey(r => r.BookId);


            foreach(var entityType in model.Model.GetEntityTypes())
            {
                foreach(var entityProperty in  entityType.GetProperties())
                {
                    if(entityProperty.ClrType == typeof(decimal) && entityProperty.Name.Contains("Price"))
                    {
                        entityProperty.SetPrecision(9);
                        entityProperty.SetScale(2);
                    }
                }
            }

           //  model.Entity<Books>().Navigation(b => b.lineItems).IsRequired(false);

            //we can use Filter_Data to filter the data that will get by user 1
            //we get the id in claims

            //model.Entity<Orders>()
            // .HasQueryFilter(x => x.CustomerId == _userId);


            //         model.Entity<Books>().HasMany(b => b.Tags).WithMany(t => t.Books).UsingEntity(j => j.ToTable("BooksTags").HasData(
            //	new {
            //	    BooksBookId = 1,TagsId = "HW"
            //	}
            //	//, new {
            //	//	BooksBookId = 2, TagsId = "FM"
            //	//}
            //             , new
            //             {
            //                 BooksBookId =3,
            //                 TagsId = "HA"
            //             }
            //             , new
            //             {
            //                 BooksBookId = 3,
            //                 TagsId = "HD"
            //             }
            //             )
            //);





            //model.Entity<Author>().HasData(
            //	  new Author { AuthorId=1, Name="joseph", WebUrl="http//helloworld.org" },
            //               new Author { AuthorId = 2, Name = "bahari", WebUrl = "http//bahari.com" },
            //               new Author { AuthorId = 3, Name = "noha", WebUrl = "http//bahari.com" },
            //               new Author { AuthorId = 4, Name = "berdi", WebUrl = "http//bahari.com" }
            //             );




            //model.Entity<Books>().HasData(
            //	  new Books
            //	  {
            //		  BookId = 1,
            //		  Title = "Hello wolrd",
            //		  Description = "basic of coding",
            //		  Publisher = "Wakanim",
            //		  PublishedOn = DateTime.UtcNow.AddDays(3).AddYears(1),
            //		  Price = 50.00m,
            //                   SoftDeleted=true
            //               },
            //	  new Books
            //	  {
            //		  BookId = 2,
            //		  Title = "foot mangering",
            //		  Description = "basic of footbal coathing",
            //		  Publisher = "Shona",
            //		  PublishedOn = DateTime.UtcNow.AddDays(8).AddYears(2),
            //		  Price = 70.00m,
            //                   SoftDeleted = true
            //               },
            //               new Books
            //               {
            //                   BookId = 3,
            //                   Title = "hardwar",
            //                   Description = "basic of hardwar tools",
            //                   Publisher = "ward",
            //                   PublishedOn = DateTime.UtcNow.AddDays(8).AddYears(1),
            //                   Price = 60.00m,
            //                   SoftDeleted = false
            //               }
            //             ); 

            //model.Entity<BookAuthor>().HasData(
            //               new BookAuthor
            //	  {
            //		BookId=1,
            //		AuthorId=1,
            //		//OrderId=1
            //	  },
            //               new BookAuthor
            //               {
            //                  BookId = 2,
            //                  AuthorId = 2,
            //		// OrderId=2
            //               },
            //               new BookAuthor
            //               {
            //                   BookId = 3,
            //                   AuthorId = 4,
            //                   //OrderId = null
            //               }

            //             );

            //model.Entity<PriceOffers>().HasData(
            //	  new PriceOffers
            //	  {
            //		  PriceOffersId=1,
            //		  NewPrice=30.00m,
            //		  PromotionalText="Save 1$ if you ordered 40 unit",
            //		  BookId=1
            //	  },
            //               new PriceOffers
            //               {
            //                   PriceOffersId = 2,
            //                   NewPrice = 20.00m,
            //                   PromotionalText = "Save 2$ if you ordered 20 unit",
            //		  BookId=2
            //               },
            //               new PriceOffers
            //               {
            //                   PriceOffersId = 3,
            //                   NewPrice = 200.00m,
            //                   PromotionalText = "Save 2$ if you ordered 20 unit",
            //                   BookId = 3
            //               }
            //             );

            //model.Entity<Review>().HasData(
            //	  new Review
            //	  {
            //		  ReviewId=1,
            //		  VoterName="anayelle",
            //		  NumStars=5.0,
            //		  Comment="I Love this book a lot",
            //		  BookId=1
            //	  },
            //               new Review
            //               {
            //                   ReviewId = 2,
            //                   VoterName = "joelle",
            //                   NumStars = 3.0,
            //                   Comment = "I hate this book",
            //                   BookId = 2
            //               },
            //               new Review
            //               {
            //                   ReviewId = 3,
            //                   VoterName = "alie",
            //                   NumStars = 1.0,
            //                   Comment = "I hate this book",
            //                   BookId = 3
            //               },
            //               new Review
            //               {
            //                   ReviewId = 4,
            //                   VoterName = "noor",
            //                   NumStars = 4.0,
            //                   Comment = "I love this book",
            //                   BookId = 3
            //               }

            //             );


            //model.Entity<Tags>().HasData(
            //	  new Tags
            //	  {
            //		  TagsId = "HW",
            //	  },
            //	  new Tags
            //	  {
            //		  TagsId = "FM",
            //	  },
            //                new Tags
            //                {
            //                    TagsId = "HA",
            //                },
            //                 new Tags
            //                 {
            //                     TagsId = "HD",
            //                 }
            //             );

            //         //model.Entity<Order>().HasData(
            //         //	   new Order { Id = 1 },
            //         //	   new Order { Id = 2 }
            //         //	);



            //         //model.Entity("BooksTags").HasData(
            //         //	  new { BooksBookId = 1, TagsId = 1 },
            //         //	  new { BooksBookId = 2, TagsId = 2 }
            //         //	);





        }

    }
}

