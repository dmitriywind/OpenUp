using iPractice.DataAccess.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace iPractice.DataAccess.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IClientsBookedTimeSlotsRepository, ClientsBookedTimeSlotsRepository>();
            services.AddTransient<IPsychologistsRepository, PsychologistsRepository>();
            services.AddTransient<IPsychologistAvailabilityRepository, PsychologistAvailabilityRepository>();
        }
    }
}
