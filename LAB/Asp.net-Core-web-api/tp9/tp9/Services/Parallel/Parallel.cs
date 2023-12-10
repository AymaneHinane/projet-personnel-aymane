using System;
using test8.Model.Library;
using test8.DB;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;

namespace tp9.Services.Parallel
{


    //Obtaining an instance of your application’s DbContext to run in parallel
    //If you want to run any code that uses EF Core in parallel, you can’t use the normal approach of getting
    //the application’s DbContext because EF Core’s DbContext isn’t thread-safe; you can’t use the same
    //instance in multiple tasks.EF Core will throw an exception if it finds that the same DbContext instance
    //is used in two tasks.


    //The important point of the code is that you provide ServiceScopeFactory to each task so that it can use DI
    //to get a unique instance of the DbContext(and any other scoped services). In addition to solving the DbContext
    //thread-safe issue, if you are running the method repeatedly, it’s best to have a new instance of
    //the application’s DbContext so that data from the last run doesn’t affect your next run.

    public class Parallel
    {
        IServiceScopeFactory _scopeFactory;
        public Parallel(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        private async Task DoWorkAsync(CancellationToken stoppingToken)
		{
            using (var scope = _scopeFactory.CreateScope())
            {
                //get a thread-safe version of the application’s DbContext
                var context = scope.ServiceProvider
                    .GetRequiredService<DBContext>();

                var numReviews = await context.Set<Review>()
                    .CountAsync(stoppingToken);
                //_logger.LogInformation(
                //    "Number of reviews: {numReviews}", numReviews);
            }

        }



    }
}

