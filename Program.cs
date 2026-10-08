using Microsoft.EntityFrameworkCore;
using ATMManagementSystem.API.Services;
using ATMManagementSystem.API.Data;
using ATMManagementSystem.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
{
    options.UseMySQL(
    builder.Configuration.GetConnectionString(
    "DefaultConnection"));
   
});

builder.Services.AddScoped< IAccountService, AccountService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();





app.UseCors("AllowAngular");
app.MapControllers();
app.Run();
