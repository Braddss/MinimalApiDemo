using Microsoft.AspNetCore.Mvc;
using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;
using MinimalApiDemo.Validation.Interfaces;

namespace MinimalApiDemo.StartUpHelpers
{
    internal static class StringController
    {
        public static WebApplication AddStringEndPoints(this WebApplication app)
        {
            app.MapPost("/api/v1/string/words/count", (IInputValidator validator, IWordCountCalculator wordCountCalculator, [FromBody] WordCountModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.WordsToCount),
                    r => wordCountCalculator.Calculate(r),
                    request);
            });

            app.MapPost("/api/v1/string/words/contains", (IInputValidator validator, IWordContainsCalculator wordContainsCalculator, [FromBody] WordContainsModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.WordsToCheck),
                    r => wordContainsCalculator.Calculate(r),
                    request);
            });

            app.MapPost("/api/v1/string/characters/count", (IInputValidator validator, ICharCountCalculator charCountCalculator, [FromBody] CharCountModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.CharsToCount.Select(c => c.ToString())),
                    r => charCountCalculator.Calculate(r),
                    request);
            });

            app.MapPost("/api/v1/string/characters/contains", (IInputValidator validator, ICharContainsCalculator charContainsCalculator, [FromBody] CharContainsModel request) =>
            {
                return ProcessRequest(
                     r => validator.CheckHasDuplicates(r.CharsToCheck.Select(c => c.ToString())),
                     r => charContainsCalculator.Calculate(r),
                     request);
            });

            return app;
        }

        private static IResult ProcessRequest<TModel>(
            Func<TModel, bool> validationCheck,
            Func<TModel, object> calculator,
            TModel request)
        {
            if (validationCheck(request))
            {
                return Results.BadRequest(new { error = "Duplicate entries found" });
            }

            var result = calculator(request);
            return Results.Ok(new { result });
        }
    }
}
