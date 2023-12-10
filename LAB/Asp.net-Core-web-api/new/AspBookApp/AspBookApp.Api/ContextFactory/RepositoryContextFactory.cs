
using AspBookApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspBookApp.Api.ContextFactory;

public class RepositoryContextFactory: IDesignTimeDbContextFactory<RepositoryContext>
{
   public RepositoryContext CreateDbContext(string[] args)
   {
       var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

    //    var builder = new DbContextOptionsBuilder<RepositoryContext>()
    //    .UseSqlServer(configuration.GetConnectionString("sqlConnection"));

       var builder = new DbContextOptionsBuilder<RepositoryContext>()
          .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
         b => b.MigrationsAssembly("AspBookApp.Api"));

       return new RepositoryContext(builder.Options);

   }

}