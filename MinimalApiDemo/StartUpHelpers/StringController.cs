using Microsoft.AspNetCore.Mvc;
using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.RequestModels;
using MinimalApiDemo.Validation.Interfaces;

namespace MinimalApiDemo.StartUpHelpers
{
    internal static class StringController
    {
        private const string StringEndpoint = "/api/v1/string";

        public static WebApplication AddStringEndPoints(this WebApplication app)
        {
            app.MapPost($"{StringEndpoint}/words/count", (IInputValidator validator, IWordCountCalculator wordCountCalculator, [FromBody] WordCountModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.WordsToCount),
                    r => wordCountCalculator.Calculate(r),
                    request);
            });

            app.MapPost($"{StringEndpoint}/words/contains", (IInputValidator validator, IWordContainsCalculator wordContainsCalculator, [FromBody] WordContainsModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.WordsToCheck),
                    r => wordContainsCalculator.Calculate(r),
                    request);
            });

            app.MapPost($"{StringEndpoint}/characters/count", (IInputValidator validator, ICharCountCalculator charCountCalculator, [FromBody] CharCountModel request) =>
            {
                return ProcessRequest(
                    r => validator.CheckHasDuplicates(r.CharsToCount.Select(c => c.ToString())),
                    r => charCountCalculator.Calculate(r),
                    request);
            });

            app.MapPost($"{StringEndpoint}/characters/contains", (IInputValidator validator, ICharContainsCalculator charContainsCalculator, [FromBody] CharContainsModel request) =>
            {
                return ProcessRequest(
                     r => validator.CheckHasDuplicates(r.CharsToCheck.Select(c => c.ToString())),
                     r => charContainsCalculator.Calculate(r),
                     request);
            });

            app.MapPost($"{StringEndpoint}/base64/check", (IBase64Calculator base64Calculator, [FromBody] TextModel request) =>
            {
                var result = base64Calculator.CalculateIsBase64String(request);

                return Results.Ok(new { result });
            });

            app.MapPost($"{StringEndpoint}/mail/check", (IMailCalculator mailCalculator, [FromBody] TextModel request) =>
            {
                var result = mailCalculator.CalculateIsValidMail(request);

                return Results.Ok(new { result });
            });

            app.MapPost($"{StringEndpoint}/conversion/decimal", (IDecimalConversionCalculator conversionCalculator, [FromBody] TextModel request) =>
            {
                var result = conversionCalculator.CalculateConversion(request);

                return Results.Ok(new { result });
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
