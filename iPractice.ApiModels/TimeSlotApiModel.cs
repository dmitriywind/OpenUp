using System;

namespace iPractice.ApiModels
{
    public class TimeSlotApiModel
    {
        public long PsychologistId { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}