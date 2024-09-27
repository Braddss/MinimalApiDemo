using Microsoft.AspNetCore.Mvc;
using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWordCountCalculator, WordCountCalculator>();

var app = builder.Build();

app.MapPost("/wordcount", (IWordCountCalculator wordCountCalculator, [FromBody] WordCountRequest request) =>
{
    var result = wordCountCalculator.CalculateWordCount(request);
    return Results.Ok(new { result });
});

app.Run();
