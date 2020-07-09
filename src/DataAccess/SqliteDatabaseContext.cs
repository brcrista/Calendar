namespace Calendar.DataAccess
{
    /// <summary>
    /// Provides details for connecting to a SQLite database.
    /// </summary>
    public sealed class SqliteDatabaseContext
    {
        public string DatabaseFilepath { get; }

        public SqliteDatabaseContext(string databaseFilepath)
        {
            DatabaseFilepath = databaseFilepath;
        }
    }
}
