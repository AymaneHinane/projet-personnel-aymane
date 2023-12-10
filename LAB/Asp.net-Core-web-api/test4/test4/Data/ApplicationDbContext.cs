using System;
using Microsoft.EntityFrameworkCore;
using test4.Model;

namespace test4.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
			:base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Game>()
				.HasOne(g => g.Genre)
				.WithMany(gg => gg.Games)
				.HasForeignKey(g => g.GenreId)
				.OnDelete(DeleteBehavior.NoAction);
				
        }

		public DbSet<Game> Games { get; set; }
		public DbSet<GameGenre> GameGenres { get; set; }
	}
}

