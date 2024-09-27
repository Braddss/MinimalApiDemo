using MinimalApiDemo.StartUpHelpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCalculators();

var app = builder.Build();

app.AddStringEndPoints();

app.Run();
