using System.Collections.Generic;
using System.Threading.Tasks;
using iPractice.Models;

namespace iPractice.DataAccess.Contracts
{
    public interface IPsychologistAvailabilityRepository
    {
        public Task<AvailabilityDto> GetAvailability(long availabilityId);

        Task<List<AvailabilityDto>> GetAvailabilityForPsychologist(long psychologistId);

        public Task<AvailabilityDto> CreateOrUpdateAvailability(AvailabilityDto availability);
    }
}
