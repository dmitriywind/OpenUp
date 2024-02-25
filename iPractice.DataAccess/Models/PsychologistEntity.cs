using System.Collections.Generic;

namespace iPractice.DataAccess.Entity.Models
{
    public class PsychologistEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ClientEntity> Clients { get; set; }
    }
}