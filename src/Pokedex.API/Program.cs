using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Data;
using Pokedex.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokedexDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Pokedex")));

var app = builder.Build();

app.MapGet("/health", () => new { success = true });

app.MapPokemonSpeciesEndpoints();

app.MapGet("/", (EndpointDataSource endpointDataSource) => {
    var endpoints = endpointDataSource.Endpoints
        .OfType<RouteEndpoint>()
        .Select(e => new {
            Route = "/" + e.RoutePattern.RawText?.TrimStart('/'),
            Methods = e.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods,
            Name = e.DisplayName
        })
        .Where(e => e.Route != "/" && e.Route != "//")
        .OrderBy(e => e.Route);

    return Results.Ok(endpoints);
});

app.Run();
