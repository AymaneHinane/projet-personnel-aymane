using System;
using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
	public class BookStoreContext:DbContext
	{
		public BookStoreContext(DbContextOptions<BookStoreContext> option):base(option)
		{
		}

		public DbSet<BookModel> Book { get; set; }

	}
}

