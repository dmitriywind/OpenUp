using System;

namespace iPractice.Models
{
    public class TimeSlotDto
    {
        public long PsychologistId { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}