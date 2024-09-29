using MinimalApiDemo.Calculators;
using MinimalApiDemo.Calculators.Interfaces;
using MinimalApiDemo.Validation;
using MinimalApiDemo.Validation.Interfaces;

namespace MinimalApiDemo.StartUpHelpers
{
    internal static class ServiceExtensions
    {
        public static IServiceCollection AddCalculators(this IServiceCollection services)
        {
            services.AddScoped<ITextCalculator, TextCalculator>()
                    .AddScoped<IWordCountCalculator, WordCountCalculator>()
                    .AddScoped<IWordContainsCalculator, WordContainsCalculator>()
                    .AddScoped<ICharCountCalculator, CharCountCalculator>()
                    .AddScoped<ICharContainsCalculator, CharContainsCalculator>()
                    .AddScoped<IBase64Calculator, Base64Calculator>()
                    .AddScoped<IMailCalculator, MailCalculator>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IInputValidator, InputValidator>();

            return services;
        }
    }
}
