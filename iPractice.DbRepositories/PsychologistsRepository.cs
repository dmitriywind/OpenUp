using System.Threading.Tasks;
using iPractice.DataAccess.Contracts;
using iPractice.Models;

namespace iPractice.DataAccess.Repository
{
    public class PsychologistsRepository : IPsychologistsRepository
    {
        public PsychologistsRepository()
        {
            
        }

        public Task<PsychologistDto> GetPsychologist(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
