using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model;
using test8.Model.Shop;
using test8.Services.BlogAuthorServices;


namespace test8.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorController:ControllerBase
	{
		private readonly IBlogRepository repository;
        private readonly DBContext context;

        public AuthorController(IBlogRepository blogRepository, DBContext dBContext)
		{
			repository = blogRepository;
            context = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }


        //[HttpGet("book")]
        //public IActionResult Book()
        //{

        //    var data = context.Books.Include(b => b.).AsNoTracking().ToList();
        //    return Ok(data);

        //}

        //[HttpGet("blog")]
        //public async Task<IActionResult> AddBlog()
        //{
        //	//await repository.AddBlog();
        //	return Ok(await repository.GetBlogs());
        //}

        [HttpGet("author")]
        public async Task<IActionResult> AddAuthor()
        {
            //await repository.AddBlog();
            //return Ok(await repository.GetAuthors());

            //return Ok(await context.Authors
            //    .Include(b => b.Blogs)

            //    .Select(x => new
            //    {
            //        FirstName=x.FirstName,
            //        Blog=x.Blogs.Select(x => EF.Property<DateTime>(x, "CreateDate")),

            //    })
            //    .ToListAsync());

            //return Ok(await context.Authors
            //    .Include(a=>a.Blogs)
            //   .ToListAsync() //is IList<Author> states ? Ok(states): (ActionResult<List<Author>>)NoContent()
            //   ) ;

            //return Ok(await context.Authors
            //         //.AsNoTracking()
            //         //.Include(a => a.Blogs.Where(b=>b.categorie.Equals(BlogCategorie.romance)))
            //         .Include(a => a.Blogs.Where(b => b.Name.Contains("hello world")))
            //         //.Where(b=>b.Blogs != null)
            //         //.Where(a=>a.FirstName.Contains("a"))
            //         //.Select(a=>new{
            //         //    FirstName=a.FirstName,
            //         //    blogs=a.Blogs.Where(b=>)
            //         //})
            //         .ToListAsync()
            //        );

            //return Ok(await context.Authors
            //           .Include(a => a.Blogs)
            //           .ThenInclude(b => b.Posts)
            //           .ToListAsync()
            //    );

            //return Ok(await context.Authors
            //           .Include(a => a.Blogs)
            //           .ThenInclude(b => b.Posts)
            //           .AsSplitQuery()
            //           .ToListAsync()
            //    );


            //using (var context = new BloggingContext())
            //{
            //    var blogs = context.Blogs
            //        .Include(blog => blog.Posts)
            //        .ThenInclude(post => post.Author)
            //        .Include(blog => blog.Posts)
            //        .ThenInclude(post => post.Tags)
            //        .ToList();
            //}

            //var result = (from author in context.Authors
            //            join blog in context.Blogs
            //            on author.Id equals blog.AuthorId
            //            select new { author,blog }
            //            ).ToList();

            //return Ok(
            //       result
            //    );


            //var result1 = await context.Products
            //          .AsNoTracking()
            //          .AsSplitQuery()
            //          .Select(x => new
            //          {
            //              Name = x.Name,
            //              Category = x.productCategory.CategoryName,
            //              CreateDate = EF.Property<DateTime>(x, "CreateDate"),
            //              Property = x.productCategory.productCategoryProperties.Select(p => new
            //              {
            //                  Property = p.productProperty.PropertyName,
            //                  PropertyValue = p.productProperty.productPropertyValue
            //                  .Where(v => v.ProductId == x.Id)
            //                  .Select(v => v.Value)
            //              })
            //          }
            //               ).ToListAsync();


            //var result2 = await context.Customers
            //            .Include(c => c.Orders).ToListAsync();


            //var result3 = context.Products
            //    //.AsNoTracking()
            //    .Single(x => x.Id == 1);

            //    context.Entry(result3)
            //    .Reference(x => x.productCategory)
            //    .Load();

            //context.Entry(result3)
            //.Collection(x => x.OrderDetails)
            //.Load();

            //context.Entry(result3)
            //.Collection(x => x.OrderDetails)
            //.Query()
            //.Where()
            //.ToList();


            // var result4 = context.Products;//.AsNoTracking();
            ////var result4 = context.Products.Include(p => p.productPropertiesValue);

            //foreach (var product in result4)
            //{

            //    product.Price *= 2;
            //}

            ////context.SaveChanges();

            //return Ok(result4);


            //var query = from customer in context.Customers//.Include(x=>x.Orders)//.AsNoTracking()
            //            //from order in customer.Orders
            //            join order in context.Orders on customer.Id equals order.CustomerId

            //            select new
            //            {
            //                customer = customer,
            //                //order = customer.Orders
            //            };


            //var query =from customer in context.Customers//.Include(x=>x.Orders)//.AsNoTracking()
            //                                              //from order in customer.Orders
            //            join order in context.Orders on customer.Id equals order.CustomerId
            //            group customer by customer.Orders into grouping

            //            select new
            //            {
            //                customer=grouping.,
            //                orders=grouping.ToList()

            //            };


            //var blogs = db.Blogs.ToList(); // <!-- Works
            //                               // var blogs = db.Blogs; // <!-- Fails

            //foreach (var blog in blogs)
            //{
            //    db.Entry(blog)
            //        .Collection(b => b.Posts)
            //        .Load();
            //}

            //var query = context.Customers
            //    .Include(c=>c.Orders)
            //    .AsEnumerable()          
            //    .GroupJoin(
            //    //.Join(
            //      inner: context.Orders,
            //      outerKeySelector: c => c.Id,
            //      innerKeySelector: o => o.CustomerId,
            //      resultSelector: (customer, o) => new
            //      {
            //          customer
            //      }
            //    ).Distinct().ToList();

            //var query = context.ProductCategories.AsEnumerable()
            //    .GroupJoin(
            //            inner: context.Products,
            //            outerKeySelector: category => category.Id,
            //            innerKeySelector: product => product.Id,
            //            resultSelector: (c, matchingProducts) => new {
            //              c.CategoryName,
            //              Products = matchingProducts.OrderBy(p => p.Name)
            //          });

            return Ok();

        }

    }
}

