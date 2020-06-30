using System;

namespace Calendar.ApiService.Models
{
    public sealed class Event
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string? Location { get; set; }

        public User? Owner { get; set; }
    }
}