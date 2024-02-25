using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPractice.DataAccess.Contracts;
using iPractice.Models;

namespace iPractice.DataAccess.Repository
{
    public class PsychologistAvailabilityRepository : IPsychologistAvailabilityRepository
    {
        public PsychologistAvailabilityRepository()
        {
            
        }
        
        public Task<AvailabilityDto> GetAvailability(long availabilityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AvailabilityDto>> GetAvailabilityForPsychologist(long psychologistId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> CreateOrUpdateAvailability(AvailabilityDto availability)
        {
            throw new NotImplementedException();
        }
    }
}
