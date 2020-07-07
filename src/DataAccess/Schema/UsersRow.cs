namespace Calendar.DataAccess.Schema
{
    /// <summary>
    /// A .NET type representing a row in the SQL table <c>Users</c>.
    /// </summary>
    public sealed class UsersRow
    {
        public long Id { get; set; }

        public string? DisplayName { get; set; }

        public long? AccountId { get; set; }
    }
}