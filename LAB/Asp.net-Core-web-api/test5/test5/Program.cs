using Microsoft.EntityFrameworkCore;
using test5.Data;
using test5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapGet("Hello",() => "hello world");


app.MapPost("api/Editor",async (DBContext context, Editor editor) =>
{
    await context.Editor.AddAsync(editor);
    await context.SaveChangesAsync();

    return true;
});





app.MapControllers();

app.Run();

