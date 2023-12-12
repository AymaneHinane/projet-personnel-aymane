


using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project.Repository;



public class RepositoryContextFactory: IDesignTimeDbContextFactory<RepositoryContext>
{

   public RepositoryContext CreateDbContext(string[] args)
   {

       var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

       var builder = new DbContextOptionsBuilder<RepositoryContext>()
          .UseNpgsql(configuration.GetConnectionString("sqlConnection"),
         b => b.MigrationsAssembly("Project.Api"));

    

       return new RepositoryContext(builder.Options,null!);

   }

}


