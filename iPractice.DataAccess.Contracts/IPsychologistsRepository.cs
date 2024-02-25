using System.Threading.Tasks;
using iPractice.Models;

namespace iPractice.DataAccess.Contracts
{
    public interface IPsychologistsRepository
    {
        public Task<PsychologistDto> GetPsychologist(long id);
    }
}
