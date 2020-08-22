using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.ObjectModel.DataProviders
{
    internal static class AsyncEnumerableExtensions
    {
        public static async Task<TRow?> AssertSingleRowAsync<TRow>(this IAsyncEnumerable<TRow> rows) where TRow : class
        {
            TRow? first = null;
            await foreach (var row in rows)
            {
                if (first != null)
                {
                    throw new DataConsistencyException($"Expected a at most one row, but multiple rows were returned.");
                }

                first = row;
            }

            return first;
        }
    }
}
