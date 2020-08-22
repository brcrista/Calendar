namespace Calendar.ObjectModel.Models
{
    public sealed class Attendee
    {
        public User? User { get; set; }

        public bool HasAccepted { get; set; }
    }
}
