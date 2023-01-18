using Components.API.DBContexts;
using Components.API.Interfaces;
using Components.API.Repositories;
using Components.API.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddDbContext<BreweryDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString(BreweryAPIConstants.CONSTANT_BREWERY_API_DB_CONNECTION_STRING)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    using (var db = serviceScope.ServiceProvider.GetRequiredService<BreweryDBContext>())
    {
        db.Database.EnsureCreated();
    }
}

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
