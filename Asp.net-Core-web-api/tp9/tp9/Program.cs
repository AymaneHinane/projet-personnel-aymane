using Microsoft.EntityFrameworkCore;
using test8.DB;
using tp9;
using tp9.Errors;
using tp9.Library;
using tp9.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(option =>
  option.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
);

builder.Services.AddControllers().AddNewtonsoftJson(op =>
   op.SerializerSettings.ReferenceLoopHandling =
       Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//builder.Services.AddScoped<IPlaceOrderDbAccess,PlaceOrderDbAccess>();
//builder.Services.AddScoped<IBizAction<PlaceOrderInDto, Orders>, PlaceOrderAction>();
//builder.Services.AddScoped(typeof(IRunnerWriterDb<,>),typeof( RunnerWriterDb<,>));
//builder.Services.AddScoped<IBizActionErrors, BizActionErrors>();
//builder.Services.AddScoped<IChangePriceOfferService, ChangePriceOfferService>();

//builder.Host

builder.Services.RegisterServicesDI();

//executer un service on background
//builder.Services.AddHostedService<BackgroundServiceTest>();

//builder.Services.AddAutoMapper();

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



