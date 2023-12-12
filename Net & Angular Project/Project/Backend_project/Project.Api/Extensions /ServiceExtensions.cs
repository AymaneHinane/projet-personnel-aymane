


using Project.Contracts;
using Project.Contracts.Logger;
using Project.LoggerService.Logger;
using Project.Repository;
using Project.Service;
using Project.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Project.Service.Contracts.security;
using Project.Service.security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Project.Api.Extensions;


public static class ServiceExtensions {

    public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
           {
              options.AddPolicy("CorsPolicy", builder => 
              builder.AllowAnyOrigin()
              .AllowAnyMethod() 
              .AllowAnyHeader()
              .WithExposedHeaders("X-Pagination"));
    });  
    
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
      services.Configure<IISOptions>(options =>
       {
       }
    );

    public static void ConfigureLoggerService(this IServiceCollection services) =>
      services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureSiteRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<IInventoryRepositoryManager, InventoryRepositoryManager>();

   public static void ConfigureSiteServiceManager(this IServiceCollection services) =>
      services.AddScoped<IInventoryServiceManager, InventoryServiceManager>();

    public static void ConfigureTransferRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<ITransferRepositoryManager, TransferRepositoryManager>();

   public static void ConfigureTransferServiceManager(this IServiceCollection services) =>
      services.AddScoped<ITransferServiceManager, TransferServiceManager>();
  
   public static void ConfigureQueryRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<IQueryRepositoryManager,QueryRepositoryManager>();

    public static void ConfigureChargeRepositoryManager(this IServiceCollection services) =>
     services.AddScoped<IChargeRepositoryManager, ChargeRepositoryManager>();

    public static void ConfigureChargeServiceManager(this IServiceCollection services) =>
         services.AddScoped<IChargeServiceManager, ChargeServiceManager>();


    public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration) =>
       services.AddDbContext<RepositoryContext>(opts => 
          opts.UseNpgsql(configuration.GetConnectionString("sqlConnection"))//.EnableSensitiveDataLogging()
           ,ServiceLifetime.Scoped
       );




    public static void ConfigureIdentity(this IServiceCollection services)
    {

        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = false;
           
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }

    public static void ConfigureSecurityServiceManager(this IServiceCollection services) =>
        services.AddScoped<ISecurityServiceManager, SecurityServiceManager>();


    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]!);

            jwt.TokenValidationParameters = new TokenValidationParameters
               {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JwtConfig:validIssuer"],
                    ValidAudience = configuration["JwtConfig:validAudience"],
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
            };
        });

    }


    public static void RoleMatchesWarehouseIdAuthorizationPolicy(this IServiceCollection services)
    {

        services.AddAuthorization(options =>
        {
            options.AddPolicy("WarehousePolicy", policy =>
            {
                policy.RequireAuthenticatedUser(); // Require authentication for this policy

                // Define a custom requirement that checks the user's role against the warehouse name
                policy.Requirements.Add(new WarehouseRoleRequirement());
            });
        });

        services.AddScoped<IAuthorizationHandler, WarehouseRoleHandler>();


    }


}