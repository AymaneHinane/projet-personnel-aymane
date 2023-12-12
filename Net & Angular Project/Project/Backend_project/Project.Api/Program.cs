using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using Project.Api.Configuration;
using Project.Api.Extensions;
using Project.Contracts.Logger;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Repository;
using Project.Service.Event;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

//LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();


builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureSiteRepositoryManager();
builder.Services.ConfigureSiteServiceManager();
builder.Services.ConfigureTransferRepositoryManager();
builder.Services.ConfigureTransferServiceManager();
builder.Services.ConfigureQueryRepositoryManager();
builder.Services.ConfigureChargeRepositoryManager();
builder.Services.ConfigureChargeServiceManager();



builder.Services.AddControllers()
          .AddApplicationPart(typeof(Project.Presentation.AssemblyReference).Assembly);


builder.Services.AddAutoMapper(typeof(Program));




builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
         //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
         options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });
        

// builder.Services.AddControllers()
//         .AddJsonOptions(options =>
//         {
//             options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//         });



builder.Services.Configure<ApiBehaviorOptions>( options => {
   options.SuppressModelStateInvalidFilter = true; });



builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<INotificationHandler<TransferCreatedDomainEvent>, TransferHistoryAddWhenTransferCreatedEventHandler>();
builder.Services.AddScoped<INotificationHandler<TransferCreatedDomainEvent>, StockUpdateWhenTransferCreatedEventHandler>();
builder.Services.AddScoped<INotificationHandler<TransferUpdatedDomainEvent>, TransferHistoryAddWhenTransferUpdatedEventHandler>();
builder.Services.AddScoped<INotificationHandler<TransferUpdatedDomainEvent>, StockUpdateWhenTransferUpdatedEventHandler>();


builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.ConfigureSecurityServiceManager();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.RoleMatchesWarehouseIdAuthorizationPolicy();




UserRoleAdminInitialData.Initialize(builder.Services.BuildServiceProvider());


var app = builder.Build();



var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);



if (app.Environment.IsProduction())
      app.UseHsts();


// if (app.Environment.IsDevelopment())
//        app.UseDeveloperExceptionPage();
// else
//      app.UseHsts();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
       ForwardedHeaders = ForwardedHeaders.All
});


app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();


app.Run();


