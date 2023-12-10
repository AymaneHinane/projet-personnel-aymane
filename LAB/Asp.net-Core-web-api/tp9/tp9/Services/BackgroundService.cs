using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model.Library;

namespace tp9.Services
{
	public class BackgroundServiceTest: BackgroundService
    {
        //Holds the delay between each call to the code to log the number of reviews
        private static TimeSpan _period = new TimeSpan(0, 1, 0, 0);

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<BackgroundServiceTest> _logger;
   

        //The IServiceScope- Factory injects the DI service that you use to create a new DI scope.

        public BackgroundServiceTest(
          IServiceScopeFactory scopeFactory,
          ILogger<BackgroundServiceTest> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync(stoppingToken);
                await Task.Delay(_period, stoppingToken);
            }
        }


        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DBContext>();
                var numReviews = await context.Set<Review>().CountAsync(stoppingToken);
                _logger.LogInformation(
                    "Number of reviews: {numReviews}", numReviews);
            }

        }

        //NB:
        //You need to register your background class with the NET DI provider, using the AddHostedService method.
        //When the Book App starts, your background task will be run first, but when your background task gets to
        //a place where it calls an async method and uses the await statement, control goes back to the ASP.NET Core
        //code, which starts up the web application.


    }


    
}

