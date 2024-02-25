using iPractice.Contracts;
using iPractice.DataAccess.Contracts;

namespace iPractice.Services
{
    public class ClientBookingService : IClientBookingService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IClientsBookedTimeSlotsRepository _clientsBookedTimeSlotsRepository;

        public ClientBookingService(
            IClientsRepository clientsRepository,
            IClientsBookedTimeSlotsRepository clientsBookedTimeSlotsRepository)
        {
            _clientsRepository = clientsRepository;
            _clientsBookedTimeSlotsRepository = clientsBookedTimeSlotsRepository;
        }
    }
}
