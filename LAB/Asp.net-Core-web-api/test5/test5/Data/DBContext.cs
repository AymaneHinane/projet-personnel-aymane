using System;
using Microsoft.EntityFrameworkCore;

using test5.Models;

namespace test5.Data
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Editor>()
				.HasMany(e => e.Studiots)
				.WithOne(s => s.Editor)
				.HasForeignKey(s => s.EditorId)
			    .OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Editor>()
				.HasMany(e => e.Games)
				.WithOne(g => g.Editor)
				.HasForeignKey(g => g.EditorId)
			    .OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Editor>()
				.HasMany(e => e.Employees)
				.WithOne(ep => ep.Editor)
				.HasForeignKey(ep => ep.Editorid)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Studiot>()
				.HasMany(s => s.Games)
				.WithMany(g => g.Studiots);

			modelBuilder.Entity<Studiot>()
			.HasMany(s => s.Employees)
			.WithOne(e => e.Studiot)
			.HasForeignKey(e => e.StudiotId)
			.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Productor>()
				.HasBaseType<Employee>();

			modelBuilder.Entity<Game>()
				.HasMany(g => g.Categories)
				.WithMany(c => c.Games)
			    .UsingEntity(j => j.ToTable("GameCategory"));


			modelBuilder.Entity<Game>()
				.HasOne(g => g.GameState)
				.WithOne(gs => gs.Game)
				.HasForeignKey<GameState>(gs => gs.GameId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Editor>()
				.Property(e => e.Name)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<Studiot>()
				.Property(s => s.Name)
				.HasMaxLength(50)
				.IsRequired();

			//modelBuilder.Entity<Employee>()
			//	.Property(ep => ep.Salary)
			//	.HasPrecision(5, 2);

			modelBuilder.Entity<GameState>()
				.Property(gs => gs.AnnoucementDate)
				.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Editor>()
				.HasIndex(e => e.Name)
				.IsUnique();

			modelBuilder.Entity<Studiot>()
	            .HasIndex(e => e.Name)
				.IsUnique();

			modelBuilder.Entity<Game>()
	            .HasIndex(e => e.Name)
				.IsUnique();

			modelBuilder.Entity<Employee>()
				.Property(e => e.FirstName)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<Employee>()
	            .Property(e => e.LastName)
            	.HasMaxLength(50)
            	.IsRequired();

			modelBuilder.Entity<Employee>()
				.HasIndex(e => new { e.LastName, e.FirstName })
				.IsUnique();

			//modelBuilder.Entity<Employee>()
			//	.HasCheckConstraint("SalaryRange", "[Salary]>3000 and [Salary]<150000");

			//modelBuilder.Entity<GameCategory>()
			//	.HasData(
			//	    new GameCategory { Category = GameCategoryEnum.FPS}
			//	 );

		}

		public DbSet<Game> Games { get; set; }
		public DbSet<GameState> GameStates { get; set; }
		public DbSet<Studiot> Studio { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Editor> Editor { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Productor> Productors { get; set; }

	}
}

