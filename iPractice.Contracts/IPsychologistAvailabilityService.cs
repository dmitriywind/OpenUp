using System.Collections.Generic;
using System.Threading.Tasks;
using iPractice.ApiModels;

namespace iPractice.Contracts
{
    public interface IPsychologistAvailabilityService
    {
        Task<AvailabilityResponse> CreateAvailability(long psychologistId, AvailabilityRequest availability);
        Task<AvailabilityResponse> UpdateAvailability(long psychologistId, long availabilityId, AvailabilityRequest availability);
        Task<List<AvailabilityResponse>> GetAvailability(long psychologistId);
    }
}
