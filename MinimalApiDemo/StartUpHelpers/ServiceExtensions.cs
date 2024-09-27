using MinimalApiDemo.Calculators;

namespace MinimalApiDemo.StartUpHelpers
{
    internal static class ServiceExtensions
    {
        public static IServiceCollection AddCalculators(this IServiceCollection services)
        {
            services.AddScoped<IWordCountCalculator, WordCountCalculator>();
            services.AddScoped<IWordContainsCalculator, WordContainsCalculator>();
            return services;
        }
    }
}
