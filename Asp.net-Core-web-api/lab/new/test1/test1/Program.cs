using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using test1.DB;
using test1.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddDbContext<ApplicationDbContext>(
       option => option.UseSqlServer(builder.Configuration.GetConnectionString("test1"))
    ) ;



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });



var app = builder.Build();

//the error handling middlewat should be declared here


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //  app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.Use(async (context, next) =>
{
    Console.WriteLine($"Logic before executing the next delegate in the Use method");
    await next.Invoke();
    //await next();
    Console.WriteLine($"Logic after executing the next delegate in the Use method");
});

//It is important to know that any middleware component that we add after
//the Map method in the pipeline won’t be executed.

app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
      Console.WriteLine("Map branch logic in the Use method before the next delegate");
      await next.Invoke();
      Console.WriteLine("Map branch logic in the Use method after the next delegate");
    });

    builder.Run(async context =>
    {
      Console.WriteLine($"Map branch response to the client in the Run method");
      await context.Response.WriteAsync("Hello from the map branch.");
    });
});

//https://localhost:7215/usingmapbranch?testquerystring=test
app.MapWhen(context =>
        context.Request.Query.ContainsKey("testquerystring"),
        builder =>
         {
             builder.Run(async context =>
                   await context.Response.WriteAsync("Hello from the MapWhen branch.") );
         });


app.Run(async context =>
{
    Console.WriteLine($"Writing the response to the client in the Run method");
    await context.Response.WriteAsync("Hello from the middleware component.");
});


app.MapControllers();

app.Run();

