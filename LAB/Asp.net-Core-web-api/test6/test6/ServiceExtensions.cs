using System;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using test6.ErrorHandle;

namespace test6
{
	public static class ServiceExtensions
	{
		public static  void ConfigureExceptionHandler( this  IApplicationBuilder app)
		{
			app.UseExceptionHandler(error =>
			{
				error.Run(async context =>
				{
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						Log.Error($"Something Went Wrong in the {contextFeature.Error}");

						var error = new Error
						{
							StatusCode = context.Response.StatusCode,
							Message = "Internal Server error please try leater"
						};


                        await context.Response.WriteAsync(error.ToString());
					}


				});
			});
		}
	}
}

