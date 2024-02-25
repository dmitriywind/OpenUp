using System;

namespace iPractice.Models
{
    public class AvailabilityDto
    {
        public long Id { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}