using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using test8.DB;
using test8.Model;

namespace test8.Services.BlogAuthorServices
{
	public class BlogRepository: IBlogRepository
    {
        private readonly DBContext context;

        public BlogRepository(DBContext dBContext)
		{
            context = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
		}

        public async Task AddBlog()
        {

            var author = new Author() {
                FirstName="yan",
                LastName="nelson"
            };
            var blogs = new Blog() {
                Author = author,
                categorie = BlogCategorie.action,
                Name = "Forever",
                //Rating = 1
            };

            context.Entry(author).Property("CreateDate").CurrentValue = DateTime.UtcNow;
            await context.AddAsync(blogs);

            var createDate = context.Entry(author).Property("CreateDate").CurrentValue;        
            await context.SaveChangesAsync();

        }

        public async Task<List<Blog>> GetBlogs()
        {
           var blogs = await context.Blogs
                .Include(b=>b.Author)
                .OrderBy(b => EF.Property<DateTime>(b, "CreateDate"))
                .ToListAsync();

            return blogs;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authors = await context.Authors
                .Include(b => b.Blogs)
                .ToListAsync();
            

            return authors;
        }

        public async Task SaveChange()
        {

        
            var modifiedEntities = context.ChangeTracker.Entries()
                .Where(e =>
                           e.State == EntityState.Added || e.State == EntityState.Modified
                      );

            foreach (var entityEntry in modifiedEntities)
            {
                if (entityEntry.Property("UpdatedDate").IsModified)
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
            }

             await context.SaveChangesAsync();

        }
    }
}

