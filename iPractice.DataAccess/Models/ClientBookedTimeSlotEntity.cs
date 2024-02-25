using System;

namespace iPractice.DataAccess.Entity.Models
{
    public class ClientBookedTimeSlotEntity
    {
        public long Id { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public ClientEntity Client { get; set; }
        public PsychologistEntity Psychologist { get; set; }
    }
}