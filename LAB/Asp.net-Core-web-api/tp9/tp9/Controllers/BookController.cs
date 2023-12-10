using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Pipelines;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using test8.DB;
using test8.Model.Library;
using tp9.Errors;
using tp9.ExtensionMethod;
using tp9.Library;
using tp9.Services;
using static System.Collections.Specialized.BitVector32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace tp9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IRunnerWriterDb<PlaceOrderInDto, Orders> _runnerWriterDb;
        private readonly DBContext context;
        private readonly IBizActionErrors _bizActionErrors;
        private readonly IChangePriceOfferService _changePriceOffer;

        public BookController(
            IRunnerWriterDb<PlaceOrderInDto, Orders> runnerWriterDb,
            DBContext _context,
            IBizActionErrors bizActionErrors,
            IChangePriceOfferService changePriceOffer
            )
        {
            context = _context;
            _runnerWriterDb = runnerWriterDb;
            _bizActionErrors = bizActionErrors;
            _changePriceOffer = changePriceOffer;
        }


        [HttpGet("All")]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await context.Books.ToListAsync();

            return Ok( books );
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddBook([FromBody] Books book)
        {
            Console.WriteLine("are added");
            context.Books.Add(book);
            await context.SaveChangesAsync();

            return Ok(book);
        }



        [HttpPost("order")]
        public IActionResult AddOrder(PlaceOrderInDto placeOrderInDto)
        {


            var result = _runnerWriterDb.RunAction(placeOrderInDto);
            if (_bizActionErrors.HasErrors)
                return NotFound(_bizActionErrors.Error);
            return Ok(result);
        }


        [HttpPost("promotion")]
        public IActionResult ChangePriceOffer(PriceOffers priceOffers)
        {
            var promtion = _changePriceOffer.AddUpdatePriceOffer(priceOffers);

            return Ok(promtion);
        }



        [HttpGet("get")]
        public IActionResult Get()
        {


            //var data = context.Books.Include(book => book.BookAuthors.Where(x=>x.AuthorId==2))
            //	 .ThenInclude(BookAuthor=>BookAuthor.Author)
            //  .ToList();

            //var data = context.Books.Include(book => book.Reviews)
            //    //.Select(book => new
            //    //{
            //    //    Title = book.Title,
            //    //    //Reviews = book.Reviews.Select(review => new
            //    //    //{
            //    //    //    comment = review.Comment
            //    //    //})
            //    //})
            //    .ToList();

            //var data = context.Books.Select(
            //         book => new
            //         {
            //             book,
            //             author = book.BookAuthors.Select(b => b.Author).Where(b => b.AuthorId == 1)
            //         }
            //      );

            //var data = context.Books.Where(b => b.BookId == 1).First();

            //the DbContext.Entry method is used to gain access to a tracked entity.
            //Load to send the query to the database and load the related data
            //context.Entry(data).Collection(b => b.BookAuthors).Load();

            //foreach(var authorbook in data.BookAuthors)
            //{
            //	context.Entry(authorbook).Reference(ab => ab.Author).Load();
            //}


            //var data = context.Books.ToList();

            //foreach(var book in data)
            //{
            //    context.Entry(book).Collection(b => b.BookAuthors).Load();
            //    // context.Entry(book).Collection(b => b.BookAuthors)  generate a query
            //    // Load() execute the query

            //    foreach (var authorbook in book.BookAuthors)
            //    {
            //        context.Entry(authorbook).Reference(ab => ab.Author).Load();
            //    }
            //}


            //var book = context.Books.First();
            //var data = context.Entry(book).Collection(b => b.Reviews)
            //     .Query()
            //     .Select(b => b.Comment)

            // the Query method  returns the instance of IQueryable(or Query Variable).

            //var data = context.Books
            //    .AsNoTracking()
            //    .MapBookToDto()
            //    .OrderBooksBy(OrderByOptions.ByVotes)
            //  //  .FilterBookBy(BooksFilterBy.ByPublicationYear, DateTime.UtcNow.AddYears(2).ToString())
            //  //  .Page(1,2)
            //    .ToList();


            //any class entity has a state
            //Any entity class instance has a State, which can be accessed via the following
            //EF Core command: context.Entry(someEntityInstance).State.The State tells EF Core
            //what to do with this instance when SaveChanges is called.Here’s a list of the pos-
            //sible states and what happens if SaveChanges is called:


            // +Added—The entity needs to be created in the database. SaveChanges inserts it.
            //+ Unchanged—The entity exists in the database and hasn’t been modified on the
            //client.SaveChanges ignores it.
            //+ Modified—The entity exists in the database and has been modified on the cli -
            //ent.SaveChanges updates it.
            //+ Deleted—The entity exists in the database but should be deleted. SaveChanges
            //deletes it.
            //+ Detached—The entity you provided isn’t tracked. SaveChanges doesn’t see it.


            //entity instance has been used as a parameter to EF Core methods(such as Add, Update, or Delete), it becomes tracked.

            //var book = new Books()
            //{
            //    Title = "Booker",
            //    Description = "book for restauration",
            //    Publisher = "restaut",
            //    PublishedOn = DateTime.UtcNow,
            //    Price = 300.00m,
            //    Reviews = new List<Review>()
            //    {
            //        new Review{
            //        VoterName = "hally",
            //        NumStars = 3,
            //        Comment = "good book"
            //        }
            //    }
            //};


            //Console.WriteLine(context.Entry(book).State); //added
            //context.Add(book); //start traking   entity state added
            //Console.WriteLine(context.Entry(book).State); //added
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(book).State); //Unchanged




            //Find() - when you want to get an item by primary key.This will return null if it can't find an item.
            //It will look in the context before going to the database (as pointed out by Yaron in the comments)
            //which can be an important efficiency factor if you need to get the same entity multiple times while the same context is alive.

            //Single() - when you expect exactly one item to be returned by a query.This will throw an exception if
            //the query does not return exactly one item.

            //SingleOrDefault() - when you expect zero or one items to be returned by a query(i.e.you are not sure
            //if an item with a given key exists). This will throw an exception if the query does not return zero or one items.
            //return null

            //First() - when you expect one or more items to be returned by a query but you only want to access the first
            //item in your code(ordering could be important in the query here). This will throw an exception if the query does
            //not return at least one item.

            //FirstOrDefault() - when you expect zero or more items to be returned by a query but you only want to access the first
            //item in your code(i.e.you are not sure if an item with a given key exists) Share


            //var currentState = context.Entry(blog).State;
            //if (currentState == EntityState.Unchanged)
            //{
            //    context.Entry(blog).State = EntityState.Modified;
            //}


            //var AuthorFound = context.Authors.SingleOrDefault(author => author.Name.Contains("ba"));
            //if (AuthorFound is null)
            //{
            //    throw new Exception("author not found");
            //}


            //var book = new Books
            //{
            //    Title = "sport start 2",
            //    Description = "book for sport",
            //    Publisher = "sporty",
            //    PublishedOn = DateTime.UtcNow,
            //    Price = 100.00m,
            //};


            //book.BookAuthors =new List<BookAuthor> {
            //    new BookAuthor { Author = AuthorFound}
            // };

            //book.BookAuthors = new List<BookAuthor> {
            //    new BookAuthor { Author = AuthorFound,Book=book}
            // };

            //context.Add(book);
            //context.SaveChanges();


            //var book = context.Books.SingleOrDefault(book => book.Title == "foot mangering");

            //if (book is null)
            //    throw new Exception("book not found");

            //book.Title = "foot team";
            //context.SaveChanges(); // it runs a method called DetectChanges

            //SaveChanges() //SELECT @@ROWCOUNT; select the number of rows that have been changed

            //+ When you want to update a specific entity and need to read it in using its primary key, you have a few options.
            //I used to use the Find command, but after some digging, I now recommend SingleOrDefault because it’s quicker than
            //the Find command. But I should point out two useful things about the Find method:

            //+ The Find method checks the current application’s DbContext to see whether the required entity instance has already
            //been loaded, which can save an access to the database. But if the entity isn’t in the application’s DbContext, the load
            //will be slower because of this extra check.

            //+ The Find method is simpler and quicker to type because it’s shorter than the SingleOrDefault version, such as context.
            //Find<Book>(key)versus context.SingleOrDefault(p => p.Bookid == key).

            //+ The upside of using the SingleOrDefault method is that you can add it to the end of a query with methods such as Include,
            //which you can’t do with Find.

            // Note: The Include() extension method cannot be used after the DbSet.Find() method.E.g.context.Students.Find(1).Include()
            // is not possible in EF Core 2.0.This may be possible in future versions.

            //The supported operations are Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Skip, and Take which should be
            //applied on the collection navigation in the lambda passed to the Include method, as shown in the below example.


            var book = context.Books.Include(b => b.Promotion).ToList();//Include(x=>x.Promotion).SingleOrDefault(x=>x.BookId ==1);
                                                                        //var book = context.Books.Include(x => x.Reviews).SingleOrDefault(x => x.BookId == 1);

            // var book = context.Customers.ToList();

            return Ok(book);
        }


        [HttpGet("update")]
        public IActionResult Update()
        {
            //for stage 1 
            //string json;
            //using (var context = new EfCoreContext(options))
            //{
            //    var author = context.Books
            //        .Where(p => p.Title == "Quantum Networking")
            //        .Select(p => p.AuthorsLink.First().Author)
            //        .Single();
            //    author.Name = "Future Person 2";
            //    json = JsonConvert.SerializeObject(author);
            //}

            //to stage 2
            //using (var context = new EfCoreContext(options))
            //{

            //    var author = JsonConvert
            //                 .DeserializeObject<Author>(json);
            //    context.Authors.Update(author);
            //    context.SaveChanges();
            //}

            //DbContext.Entry(object).State = EntityState.Modified.

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++


            // Now, what happens if there’s an existing promotion on the book(that is, the Promo - tion property
            // in the Book entity class isn’t null)? That case is why the Include(p => p.Promotion) command in the
            // query that loaded the Book entity class is so important.Because of that Include method, EF Core will
            // know that an existing PriceOffer is assigned to this book and will delete it before adding the new version.

            //To be clear, in this case you must use some form of loading of the relationship— eager, explicit, select,
            //or lazy loading of the relationship—so that EF Core knows about it before the update. If you don’t, and if
            //there’s an existing relationship, EF Core will throw an exception on a duplicate foreign key BookId, which
            //EF Core has placed a unique index on, and another row in the PriceOffers table will have the same value.


            //get the first book how dont have promotion
            // var book = context.Books
            //          .Include(p => p.Promotion)
            //          //.First(p => p.Promotion == null);
            //          .First();


            //book.Promotion = new PriceOffers
            //{
            //    NewPrice = book.Price / 2,
            //    PromotionalText = "Half price today!"
            //};

            //context.SaveChanges();

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //pour ajouter une reduction je dois recuperer toute les reduction sinon
            //book.PriceOffers.Add() vat returner une null exception
            //neomoin le faite de recuperer toutes les related entity n'est pas tres performant
            //voila pourquoi cette facon de faire reste  tres performante

            //var book = context.Books
            //          .First(p => p.Promotion == null);


            //context.Add(new PriceOffers
            //{
            //    BookId = book.BookId,
            //    NewPrice = book.Price / 2,
            //    PromotionalText = "Half price today!"
            //  });
            //context.SaveChanges();

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++


            //var book = context.Books
            // .Include(p => p.Reviews)
            // .First();
            //book.Reviews.Add(new Review
            //{
            //    VoterName = "Unit Test",
            //    NumStars = 5,
            //    Comment = "Great book!"
            //});
            //context.SaveChanges();

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            //a new review will be added to the databse
            //the older reviews will be not deleted
            //The old versions will still be in the database after the update because EF Core didn’t know about them
            //at the time of the update.

            //var book = context.Books
            //.Single(p => p.BookId == 1);

            //book.Reviews = new List<Review>{
            //         new Review {
            //              VoterName = "Unit Test",
            //              NumStars = 5,
            //              Comment="good book"
            //          }
            // };

            //context.SaveChanges();

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            //because i use include ef core will now that i replace the oldest list with a new one
            //the older reviews will be deleted
            //The loading of the existing collection is important for these changes: if you don’t load them,
            //EF Core can’t remove, update, or replace them. 

            //var book = context.Books
            //  .Include(p => p.Reviews)
            //  .Single(p => p.BookId == 1);

            //book.Reviews = new List<Review>{
            //         new Review {
            //              VoterName = "Unit Test",
            //              NumStars = 5,
            //              Comment="good book"
            //          }
            // };

            //context.SaveChanges();


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //var book = context.Books.Single(x => x.BookId == 1);

            //context.Add(new PriceOffers
            //{
            //    BookId=book.BookId,
            //    NewPrice=book.Price*3,
            //    PromotionalText="hello"
            //});

            //context.SaveChangesAsync();


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            //var book = context.Books.Include(x => x.Tags).SingleOrDefault(x => x.BookId == 1);

            //var TagsCreate = new Tags { TagsId = "HO" };
            ////or
            ////var existingTag = context.Tags
            ////                .Single(p => p.TagId == "HD");
            ////or
            // var existingTag = context.Find<Tags>("HD");

            //book.Tags.Add(existingTag);

            // context.SaveChangesAsync();

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //        var reviewToChange = context
            //            .Find<Review>(dto.ReviewId);

            //            reviewToChange.BookId = dto.NewBookId;
            //            context.SaveChanges();

            //changer le livre auqu'elle appartient cette reviews
            var ExistReviews = context.Find<Review>(4);

            ExistReviews.BookId = 1;

            context.SaveChanges();

            //DbContext.Entry(object).State

            return Ok(ExistReviews);
        }


        [HttpDelete("delete")]
        public IActionResult delete()
        {

            //  NOTE The Author and Tag linked to the Book aren’t deleted because they are not dependent entities
            //  of the Book; only the BookAuthor and BookTag linking entities are deleted.This arrangement makes
            //  sense because the Author and Tag might be used on other Books.


            // if a customer orders a book, you want to keep that order informa-tion even if the book is no longer for
            // sale.In this case, you change the EF Core’s on - delete action to Restrict and remove the ON DELETE CASCADE
            // from the foreign-key constraint in the database so that an error will be raised if an attempt to delete the
            // book is made.



            //when i use include the related intity that i specify will be tracked
            //sow when we will delete the principale entity all the related entity will be also deleted

            //if i don't use include to get related entity the related will be also deleted in cascade  delete
            // unless if the foreigh key are nullable type in this case the FK will replaced with null

            //var book = context.Books
            //.Include(p => p.Promotion)
            //.Include(p => p.Reviews)
            //.Include(p => p.BookAuthors)
            //.Include(p => p.Tags)
            //.Single(p => p.Title == "Quantum Networking");
            //context.Books.Remove(book);
            //context.SaveChanges();
            return Ok();
        }



        [HttpGet("fixupStage")]
        public async Task<IActionResult> GetfixupStage()
        {
            //1
            //var book = context.Books.Include(b => b.Reviews).ToList();

            //2
            //var book = context.Books.SingleOrDefault(b => b.BookId == 1001);
            ////the review will automatically licked to book in memory
            //var review = context.Set<Review>().Where(r=>r.BookId == 1001).ToList();

            //3
            //les reviews seront linker a book
            //var book = await context.Set<Books>().ToListAsync(); //.Include(b=>b.Tags)
            //var reviews=await context.Set<Review>().ToListAsync();



            //var tag = new Tags() { Books = book, TagsId = "AB" };
            //context.Add(tag);
            //context.SaveChanges();



            //AsNoTraking() annule le trackage donc mais 2 entite ne seront pas lier ni meme tracker au modification
            //var book = await context.Set<Books>().AsNoTracking().SingleOrDefaultAsync(b => b.BookId == 1014); //.Include(b=>b.Tags)
            //var bookauthor = await context.Set<Review>().ToListAsync();

            //var book = await context.Set<Books>()
            //   // .AsNoTrackingWithIdentityResolution()
            //    .Include(b=>b.Reviews)
            //    .Where(b => new[] { 1001, 1003 }.Any(n => n == b.BookId)).
            //    ToListAsync();
            //  var reviews= await context.Set<Review>().AsNoTrackingWithIdentityResolution().ToListAsync();


            //book.Where(b => b.BookId == 1003).Single().Reviews.Where(r => r.ReviewId == 1003).Single().ReviewId = 1001;

            //book.Where(b => b.BookId == 1001).Single().Reviews
            //    .Add( book.Where(b => b.BookId == 1003)
            //          .Single()
            //            .Reviews.Where(r => r.ReviewId == 1001)
            //            .Single()
            //        );


            ////////////////////////////////////////////

            //var review = new Review() { BookId = 100 };


            //context.Update(review);
            //context.SaveChanges();

            //var book =context.Books.Where(b=>b.BookId == 1003).Single();



            //var book1001 = await context.Books
            //   // .Include(b => b.Reviews.Where(r => r.ReviewId == 1001))
            //    .Where(b => b.BookId == 1001)
            //    .Select(b => b.Reviews.Where(r => r.ReviewId == 1001).SingleOrDefault())              
            //    .SingleOrDefaultAsync();//.ToListAsync();//.SingleAsync();



            ////////////////////////////////////////////////////////////////

            //var Orders = await context.Orders
            //   // .Where(o => o.lineItems.Any(li => li.BookId == 1001))
            //  // .Where(o => o.lineItems.Select(li =>new[] {1001}.Contains(li.BookId))//(li => li.BookId == 1001))
            //    .Select(o => new
            //    {
            //        o,
            //       // book = o.lineItems.Select(li => li.Book)
            //       book = o.lineItems.Select(li => new[] { 1001 }.Contains(li.BookId))
            //    })
            //    .ToListAsync();

            //// var  Books = await context.Books.ToListAsync();
            //// var  LineItems = await context.Set<LineItem>().ToListAsync();



            //Exist => any
            //in => Contains

            // var bookIds = await context.Set<LineItem>()
            //.Where(li => li.BookId == 1001)
            //.Select(li => li.BookId)
            //.ToArrayAsync();


            /////////////////////////////////////////////////////////

            //var LigneItems = await context.Set<LineItem>()
            //    .AsNoTrackingWithIdentityResolution()
            //  // .AsNoTracking()
            //    .Include(li=>li.Book)               
            //    .Where(li => li.BookId == 1001)
            //    .ToListAsync();

            //var book1 = LigneItems.Where(li => li.OrderId == 5).Select(li => li.Book).Single();
            //book1.Price = 33;

            //var book2 = LigneItems.Where(li => li.OrderId == 6).Select(li => li.Book).Single();

            //context.Update(book1);


            /////////////////////////////////////////////////////////

            //  var Orders = context.Orders
            //.AsNoTrackingWithIdentityResolution()
            //.AsSplitQuery()
            //.Include(o => o.lineItems)                       
            //.ThenInclude(li => li.Book)
            //.ToList();


            /////////////////////////////////////////////////////////

            //  var Orders = context.Orders
            //.AsNoTrackingWithIdentityResolution()
            //.AsSplitQuery()
            //.Include(o => o.lineItems)
            //.ThenInclude(li => li.Book)
            //.ToList();


            //var LineItems = Orders.Where(o => o.Id == 5).SingleOrDefault().lineItems;

            //LineItems.Add(new LineItem() { BookId = 1007, Quatity = 7 });
            //context.Update(Orders);

            //var LineItems = new LineItem() { BookId = 1005, Quatity = 7, OrderId = 5 };
            //context.Add(LineItems);

            //context.SaveChanges();


            //var LineItems = context.Set<LineItem>().AsQueryable();//.ToListAsync();

            //foreach(var lineitem in LineItems)
            //{
            //    if (lineitem.Quatity == 0)
            //        lineitem.Quatity = 3;
            //}


            // context.SaveChanges();


            //var Orders1 = await context.Orders
            //.AsNoTrackingWithIdentityResolution()
            //.AsSplitQuery()           
            //.Where(o => o.lineItems != null)
            //.Select(o => new
            //{
            //    OrderId = o.Id,
            //    CustomerId = o.CustomerId,
            //    Total = o.lineItems.Select(li => new { Quantity = li.Quatity, Price = li.Book.Price })
            //})
            //.ToListAsync();

            //////////////Complexe query//////////////////

            //var query1 = from order in context.Orders
            //            join lineItem in context.Set<LineItem>() on order.Id equals lineItem.OrderId
            //            join book in context.Books on lineItem.BookId equals book.BookId
            //            select (new { order, book });



            //left join
            var query2 = from order in context.Orders
                         from lineItems in context.Set<LineItem>().Where(li => li.OrderId == order.Id).DefaultIfEmpty()//left join
                         where lineItems != null //inner join
                         select (new { order, lineItems });

            //inner join
            var query3 = from order in context.Orders
                         from lineItems in context.Set<LineItem>().Where(li => li.OrderId == order.Id)
                         select (new { order, lineItems });


            var query4 = from order in context.Orders.Select(o => new { o.Id, o.CustomerId })
                         from lineItems in context.Set<LineItem>().Where(li => li.OrderId == order.Id).Select(li => new { li.BookId, li.OrderId, li.Quatity, prices = li.Book.Price })
                         group new { order, lineItems } by new { order.Id, order.CustomerId, lineItems.OrderId, lineItems } into o
                         select (new { o.Key.Id, o.Key.CustomerId, o.Key.lineItems });


            var query5 = from Customer in context.Customers
                         join Order in context.Orders on Customer.CustomerId equals Order.CustomerId
                         join LineItem in context.Set<LineItem>() on Order.Id equals LineItem.OrderId
                         join Book in context.Books on LineItem.BookId equals Book.BookId
                         group new { Customer, LineItem, Book } by new { Customer.CustomerId } into group1
                         select new
                         {

                             CustomerId = group1.Key.CustomerId,
                             Total = group1.Sum(x => x.LineItem.Quatity * x.Book.Price)
                         };

            var query55 = await context.Set<LineItem>()
                          //.Include(li=>li.Order)
                          .GroupBy(li => new { li.Order.CustomerId })
                          .Select(li => new
                          {
                              CustomerId = li.Key.CustomerId,
                              Total = li.Sum(x => x.Quatity * x.Book.Price)
                          })
                          
                          .ToListAsync();



            var query6 = from Customer in context.Customers
                         join Order in context.Orders on Customer.CustomerId equals Order.CustomerId
                         join LineItem in context.Set<LineItem>() on Order.Id equals LineItem.OrderId
                         join Book in context.Books on LineItem.BookId equals Book.BookId
                         group Customer by Customer.CustomerId into g
                         select new
                         {

                             CustomerId = g.Key,
                             Total = g.Count()
                         };

            return Ok(new { query5 , query55 });

        }



        [HttpGet("AsNoTrakingCall")]
        public async Task<IActionResult> AsNoTrakingCall()
        {
            var Book = await context.Books
                // .AsNoTrackingWithIdentityResolution()
                .Include(b => b.BookAuthors.Where(bo=>bo.AuthorId == 1001 ))
           
                .ToListAsync();
            //var Book2 = await context.Books.Include(b => b.BookAuthors).Where(b => b.BookId == 1003).SingleOrDefaultAsync();


           // context.Authors.Where(a => a.AuthorId == 1001).SingleOrDefault().AuthorId = 5000;

           


            //var LigneItems = await context.Set<LineItem>()
            //   // .AsNoTrackingWithIdentityResolution()
            //    // .AsNoTracking()
            //    .Include(li => li.Book)
            //    .Where(li => li.BookId == 1001)
            //    .ToListAsync();

            //var book1 = LigneItems.Where(li => li.OrderId == 5).Select(li => li.Book).Single();
            //book1.Price = 33;

            //var book2 = LigneItems.Where(li => li.OrderId == 6).Select(li => li.Book).Single();

            // context.Update(book1);



            return Ok(Book);
        }


        [HttpGet("AddBook")]
        public async Task<IActionResult> AddNewBook()
        {

            ///////////////////one to many///////////////////
            //var book =await context.Books
            //   // .Include(b => b.Reviews)
            //    .SingleOrDefaultAsync(x => x.BookId == 1001);

            //book.Reviews = new List<Review>();
            //book.Reviews.Add(new Review { Comment = "hello", NumStars = 5, VoterName = "aymane" });
            //await  context.SaveChangesAsync();


            //var data = await context.Books
            //    .Include(b=>b.Reviews)
            //    .SingleOrDefaultAsync(x => x.BookId == 1001);


            //////////////////many to many//////////////////


            //var author = await context.Authors
            //    .Include(a => a.BookAuthors)
            //    .FirstOrDefaultAsync(a => a.AuthorId == 1001);


            //var bookauthor = new BookAuthor() { Author = author };

            //var book = new Books()
            //{
            //    Description = "hello",
            //    Price = 44,
            //    Title = "Noor Wedg",
            //    Publisher="nada",
            //    BookAuthors = new List<BookAuthor>() { bookauthor }
            //};

            ////book detached
            //  // bookId 0
            ////bookauthor detached
            //  //bookId 0
            //  //authorId 0
            ////book unchanged
            //  //authorId 123


            ////detached mean that entity are not yet added


            //context.Add(book);

            ////book added
            //// bookId (-2133...)
            ////bookauthor added
            ////bookId (-2133...)
            ////authorId 123
            ////book unchanged
            ////authorId 123

            ////added mean that entity are added loacally but not yet saved in db

            //await context.SaveChangesAsync();

            ////book unchanged
            //// bookId 456
            ////bookauthor unchanged
            ////bookId 456
            ////authorId (123)
            ////book unchanged
            ////authorId 123

            ///////////////create copy///////////////////

            ////detached
            //var order = await context.Orders
            //    .AsNoTracking()
            //    .Include(o => o.lineItems)
            //    .SingleAsync(o => o.Id == 11);


            //order.Id = default;

            ////foreach(var line in order.lineItems)
            ////{
            ////    line.OrderId = default;
            ////}

            //context.Add(order);
            //await context.SaveChangesAsync();

            //var orders = await context.Orders
            //    .Include(o => o.lineItems)
            //    .ToListAsync();


            ////////////remove entity/////////////////

            //var order = new Orders { Id = 13 };

            //context.Remove(order);
            //await context.SaveChangesAsync();

            //var orders = await context.Orders
            //    .Include(o => o.lineItems)
            //    .ToListAsync();


            var data = await context.Books.ToListAsync();



            return Ok(data);
        }


        [HttpGet("conrrency")]
        public async Task<IActionResult> addBookCurrency()
        {

            //context.concurrencyBooks.Add(new()
            //{
            //    PublishOn = new DateTime(),
            //    Title = "concurrency 1"
            //});

            //await context.SaveChangesAsync();


            var firstBook = await context.concurrencyBooks.FirstAsync();

            await context.Database.ExecuteSqlRawAsync("update dbo.concurrencyBooks " +
                "set PublishOn = GETDATE()" +
                "where ConcurrencyBookId = @p0",
                firstBook.ConcurrencyBookId);

            firstBook.Title = Guid.NewGuid().ToString();
            await context.SaveChangesAsync();


            //an exception will be raised
            //DbUpdateConcurrencyException.

            //ef core will check if the PublishedOn have the same value as the same time when he was get

            //SET NOCOUNT ON;
            //UPDATE[Books] SET[Title] = @p0
            //WHERE[ConcurrencyBookId] = @p1
            //AND[PublishedOn] = @p2;
            //SELECT @@ROWCOUNT;

            //When EF Core runs this SQL command, the WHERE clause finds a valid row to update only
            //if the PublishedOn column hasn’t changed from the value EF Core read in from the database.




            return Ok( await context.concurrencyBooks.ToListAsync() );
        }
    }
}

