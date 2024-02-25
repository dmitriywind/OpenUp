using iPractice.Contracts;
using iPractice.DataAccess.Contracts;

namespace iPractice.Services
{
    public class PsychologistsService : IPsychologistsService
    {
        private readonly IPsychologistsRepository _psychologistsRepository;

        public PsychologistsService(IPsychologistsRepository psychologistsRepository)
        {
            _psychologistsRepository = psychologistsRepository;
        }
    }
}
