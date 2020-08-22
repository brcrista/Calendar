namespace Calendar.DataAccess.Schema
{
    /// <summary>
    /// A .NET type representing a row in the SQL table <c>UserEvents</c>.
    /// </summary>
    public sealed class UserEventsRow
    {
        public long UserId { get; set; }

        public long EventId { get; set; }

        public long Accepted { get; set; }
    }
}