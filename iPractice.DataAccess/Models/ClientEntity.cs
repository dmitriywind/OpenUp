using System.Collections.Generic;

namespace iPractice.DataAccess.Entity.Models
{
    public class ClientEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PsychologistEntity> Psychologists { get; set; }
    }
}