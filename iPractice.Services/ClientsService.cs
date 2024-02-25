using iPractice.Contracts;
using iPractice.DataAccess.Contracts;

namespace iPractice.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
    }
}
