namespace Calendar.DataAccess.Schema
{
    /// <summary>
    /// A .NET type representing a row in the SQL table <c>Events</c>.
    /// </summary>
    public sealed class EventsRow
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Start { get; set; }

        public string? End { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public long? OwnerId { get; set; }
    }
}