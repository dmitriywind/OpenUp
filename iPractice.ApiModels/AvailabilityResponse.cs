using System;

namespace iPractice.ApiModels
{
    public class AvailabilityResponse
    {
        public long Id { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}