using System;

namespace iPractice.ApiModels
{
    public class AvailabilityRequest
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}