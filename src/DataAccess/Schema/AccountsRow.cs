namespace Calendar.DataAccess.Schema
{
    /// <summary>
    /// A .NET type representing a row in the SQL table <c>Accounts</c>.
    /// </summary>
    public sealed class AccountsRow
    {
        public long Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}