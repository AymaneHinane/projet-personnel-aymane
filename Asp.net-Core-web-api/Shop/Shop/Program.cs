using Microsoft.EntityFrameworkCore;
using Shop.DB;
using Shop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson( options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DBContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("StorDB"))
);

builder.Services.AddTransient<IClientRepository, ClientRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

