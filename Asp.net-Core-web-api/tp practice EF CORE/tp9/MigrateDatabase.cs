using System;
using Microsoft.EntityFrameworkCore;
using test8.DB;

namespace tp9
{
	public static class MigrateDatabase
	{
		
		//page 149
		public static async Task MigrateDatabaseAsync(this IHost WebHost)
		{
			using (var scope = WebHost.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				using (var context = services.GetRequiredService<DBContext>())
				{
					try
					{
						await context.Database.MigrateAsync();
					}
					catch (Exception ex)
					{
						var logger = services.GetRequiredService<ILogger<Program>>();
						logger.LogError(ex, "An error occurred while migrating the database.");
						throw;
					}
				}
			}

		}
	}
}


