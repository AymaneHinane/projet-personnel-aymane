using Microsoft.EntityFrameworkCore;
using test6.DB;
using Serilog;
using Serilog.Events;
using test6.Services.IUnitOfWork;
using test6.Configurations;
using test6;

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .File(
    path: "/Users/aymanehinane/Desktop/Asp.net-Core-web-api/test6/test6/log.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information
    ).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(option =>
   option.UseSqlServer(builder.Configuration.GetConnectionString("CarDB"))
);

builder.Services.AddControllers().AddNewtonsoftJson(op =>
   op.SerializerSettings.ReferenceLoopHandling =
       Newtonsoft.Json.ReferenceLoopHandling.Ignore
);




builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyMethod()
        );
});

builder.Services.AddAutoMapper(typeof(MapperInitilizer));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();


try
{
    Log.Information("application starting");
    app.Run();
}catch(Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}
