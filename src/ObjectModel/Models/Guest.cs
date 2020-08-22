namespace Calendar.ObjectModel.Models
{
    public sealed class Guest
    {
        public User? User { get; set; }

        public bool HasAccepted { get; set; }
    }
}
