using Microsoft.AspNetCore.Mvc;
using MinimalApiDemo.Calculators;
using MinimalApiDemo.RequestModels;

namespace MinimalApiDemo.StartUpHelpers
{
    internal static class StringController
    {
        public static WebApplication AddStringEndPoints(this WebApplication app)
        {
            app.MapPost("/api/v1/words/count", (IWordCountCalculator wordCountCalculator, [FromBody] WordCountModel request) =>
            {
                var result = wordCountCalculator.Calculate(request);
                return Results.Ok(new { result });
            });

            app.MapPost("/api/v1/words/contain", (IWordContainsCalculator wordContainsCalculator, [FromBody] WordContainsModel request) =>
            {
                var result = wordContainsCalculator.Calculate(request);
                return Results.Ok(new { result });
            });

            return app;
        }
    }
}
