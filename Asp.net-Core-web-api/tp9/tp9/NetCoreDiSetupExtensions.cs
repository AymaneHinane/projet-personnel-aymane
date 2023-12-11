using System;
using System.Reflection;
using tp9.Errors;
using tp9.Library;
using tp9.Services;

namespace tp9
{
	//page 144
	public static class NetCoreDiSetupExtensions
	{

		public static void RegisterServicesDI(this IServiceCollection services)
		{
            services.AddScoped<IPlaceOrderDbAccess, PlaceOrderDbAccess>();
            services.AddScoped<IBizAction<PlaceOrderInDto, Orders>, PlaceOrderAction>();
            services.AddScoped(typeof(IRunnerWriterDb<,>), typeof(RunnerWriterDb<,>));
            services.AddScoped<IBizActionErrors, BizActionErrors>();
            services.AddScoped<IChangePriceOfferService, ChangePriceOfferService>();
        }

        //public NetCoreDiSetupExtensions()
        //{
        //}

        //public static void RegisterServiceLayerDi(this IServiceCollection services, params Assembly[] assemblies)
        //{
        //          services.Scan(scan => scan.FromAssemblies(assemblies)
        //      .AddClasses(classes => classes.WithAttribute<AutoBindAttribute>())
        //      .AsImplementedInterfaces()
        //      .WithTransientLifetime();

        //      }

        //      public static void AutoBind(this IServiceCollection source, params Assembly[] assemblies)
        //      {
        //          source.Scan(scan => scan.FromAssemblies(assemblies)
        //           .AddClasses(classes => classes.WithAttribute<AutoBindAttribute>())
        //           .AsImplementedInterfaces()
        //           .WithTransientLifetime();
        //      }

    }
}

