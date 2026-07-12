using Microsoft.EntityFrameworkCore;
using reword.src.Data;
using reword.src.Repositories;// Add services to the container.
using reword.src.Services;// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
// using reword.src.Services;

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped< UserRepository>();
builder.Services.AddScoped< AuthService>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

// Testing endpoint
app.MapGet("/", () =>
{
   
    return "Hello World The Server is running";
});

app.Run();
