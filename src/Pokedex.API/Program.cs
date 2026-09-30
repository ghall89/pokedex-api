using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Data;
using Pokedex.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokedexDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Pokedex")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => new { success = true });

app.MapPokemonSpeciesEndpoints();

app.Run();
