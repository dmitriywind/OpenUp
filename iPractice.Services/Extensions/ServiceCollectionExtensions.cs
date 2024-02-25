using iPractice.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace iPractice.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IClientBookingService, ClientBookingService>();
            services.AddTransient<IPsychologistsService, PsychologistsService>();
            services.AddTransient<IPsychologistAvailabilityService, PsychologistAvailabilityService>();
        }
    }
}
