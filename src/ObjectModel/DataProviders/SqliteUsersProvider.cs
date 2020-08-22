using System.Collections.Generic;
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
            var row = await resultRows.AssertSingleRowAsync();
            if (row is null)
            {
                return null;
            }

            var result = new User
            {
                Id = row.Id,
                DisplayName = row.DisplayName,
                AccountId = row.AccountId
            };

            return result;
        }

        public IAsyncEnumerable<User> GetContactsAsync(long id)
        {
            // TODO
            return AsyncEnumerable.Empty<User>();
        }
    }
}
