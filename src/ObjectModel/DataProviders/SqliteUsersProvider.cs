using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Calendar.DataAccess;
using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class SqliteUsersProvider : IUsersProvider
    {
        private readonly UsersTableAccess usersTable;

        public SqliteUsersProvider(UsersTableAccess usersTable)
        {
            this.usersTable = usersTable;
        }

        public async Task<User?> GetUserAsync(long id)
        {
            var resultRows = usersTable.GetUsersAsync(id);

            User? result = null;
            await foreach (var row in resultRows)
            {
                Debug.Assert(result == null, "Since `id` is a primary key, we should get at most one row back.");

                result = new User
                {
                    Id = row.Id,
                    DisplayName = row.DisplayName,
                    AccountId = row.AccountId
                };
            }

            return result;
        }

        public Task<IEnumerable<User>> GetContactsAsync(long id)
        {
            // TODO
            return Task.FromResult(Enumerable.Empty<User>());
        }

        public Task<IEnumerable<Event>> GetEventsAsync(int id, int? hostId, bool? hasAccepted)
        {
            // TODO
            return Task.FromResult(Enumerable.Empty<Event>());
        }
    }
}
