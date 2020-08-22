using System;
using System.Collections.Generic;

namespace Calendar.ObjectModel.Models
{
    public sealed class Event
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public User? Owner { get; set; }

        public IList<Attendee> Attendees { get; set; } = new List<Attendee>();
    }
}