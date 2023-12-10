using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Repository;
using test.Repository.ClientRepository;
using test.Repository.CommandeRepository;
using test.Repository.MagasinRepository;
using test.Repository.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//app.UseExceptionHandler();

builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(option =>
  // option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("dbStringConnection"))
  option.UseSqlServer(builder.Configuration.GetConnectionString("dbStringConnection"))
);



builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddTransient(typeof(IRepository<>),typeof(EfCoreRepository<>));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<IMagasinRepository, MagasinRepository>();

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

