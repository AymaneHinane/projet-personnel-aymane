using System;
namespace test1.Extentions
{
	public static class ServiceExtensions
	{


		public static void ConfigureCors(this IServiceCollection services) =>
		   services.AddCors(option =>
		   {
			   option.AddPolicy("CorsPolicy", builder =>
				 builder.AllowAnyOrigin()
				 .AllowAnyMethod()
				 .AllowAnyHeader()
				 
			   );
		   });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
              services.Configure<IISOptions>(options =>{

               });
            }
}

