
using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;


var builder = WebApplication.CreateBuilder(args);


{
   builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

   //builder.Services.AddScoped<IAuthenticationService,AuthenticationService>(); 
        
   builder.Services.AddControllers(); 
}

var app = builder.Build();

{
   app.UseHttpsRedirection();

   app.MapControllers();

   app.Run();
 
}

