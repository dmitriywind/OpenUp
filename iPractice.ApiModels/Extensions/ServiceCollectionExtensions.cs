using iPractice.ApiModels.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace iPractice.ApiModels.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddSingleton<AvailabilityRequestValidator>();
        }
    }
}
