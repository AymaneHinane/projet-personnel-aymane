using System;
using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			modelBuilder.Entity<Client>()
				.Property(c => c.FullName)
				.HasComputedColumnSql("[FirstName]+' '+[LastName]");


			modelBuilder.Entity<Author>()
				.Property(a => a.FullName)
				.HasComputedColumnSql("[FirstName]+' '+[LastName]");

			modelBuilder.Entity<Employee>()
				.Property(e => e.FullName)
				.HasComputedColumnSql("[FirstName]+' '+[LastName]");

			modelBuilder.Entity<Order>()
				.Property(o => o.OrderDate)
				.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Client>()
				.HasOne(c => c.Adresse)
				.WithOne(a => a.Client)
				.HasForeignKey<Adresse>(a => a.ClientId);



			modelBuilder.Entity<EmployeeJob>()
				.HasMany(ej => ej.Employees)
				.WithOne(e => e.EmployeeJob)
				.HasForeignKey(e => e.EmployeeJobId);

			modelBuilder.Entity<Library>()
				.HasMany(l => l.Employees)
				.WithOne(e => e.Library)
				.HasForeignKey(e => e.LibraryId);
			
			modelBuilder.Entity<Library>()
				.HasOne(l => l.Adresse)
				.WithOne(a => a.Library)
				.HasForeignKey<Adresse>(a => a.LibraryId);

			modelBuilder.Entity<Category>()
				.HasMany(c => c.Books)
				.WithOne(b => b.Category)
				.HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.Library)
				.WithMany(l => l.Orders)
				.HasForeignKey(l => l.LibraryId);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.Client)
				.WithMany(c => c.Orders)
				.HasForeignKey(c => c.ClientId);

			modelBuilder.Entity<OrderDetails>()
				.HasKey(od => new {od.BookId,od.OrderId });

			modelBuilder.Entity<OrderDetails>()
				.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(o => o.OrderId);

			modelBuilder.Entity<OrderDetails>()
				.HasOne(od => od.Book)
				.WithMany(b => b.OrderDetails)
				.HasForeignKey(b => b.BookId);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.Orders)
				.WithOne(o => o.Employee)
				.HasForeignKey(o => o.EmployeeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<LibraryBook>()
				.HasKey(lb => new { lb.BookId, lb.LibraryId });

			modelBuilder.Entity<LibraryBook>()
				.HasOne(lb => lb.Library)
				.WithMany(l => l.LibraryBooks)
				.HasForeignKey(l => l.LibraryId);

			modelBuilder.Entity<LibraryBook>()
				.HasOne(lb => lb.Book)
				.WithMany(b => b.LibraryBooks)
				.HasForeignKey(b => b.BookId);

        }

		public DbSet<Client>? Clients { get; set; }
        public DbSet<Library>? Libraries { get; set; }
		public DbSet<Adresse>? Adresses { get; set; }
		public DbSet<Author>? Authors { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Book>? Books { get; set; }
		public DbSet<Order>? Orders { get; set; }
		public DbSet<OrderDetails>? OrderDetails { get; set; }
		public DbSet<Employee>? Employees { get; set; }
		public DbSet<EmployeeJob>? EmployeeJobs { get; set; }

	}
}

