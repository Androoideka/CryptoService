using CryptoService.Core.Repositories;
using CryptoService.Core.Seeders;
using CryptoService.Core.Services;
using CryptoService.Infrastructure.Data;
using CryptoService.Infrastructure.Repositories;
using CryptoService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("crypto"));
builder.Services.AddScoped<IRepository<Symbol>, SymbolRepository>();
builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<CryptocurrencyService, CryptocurrencyService>();
builder.Services.AddScoped<Loader<Symbol>, TestLoader>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var loader = scopedProvider.GetRequiredService<Loader<Symbol>>();
        await loader.Initialize();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred while seeding.");
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
