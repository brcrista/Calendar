using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.ObjectModel.DataProviders
{
    internal static class AsyncEnumerableExtensions
    {
        public static async Task<TRow> AssertSingleRowAsync<TRow>(this IAsyncEnumerable<TRow> rows) where TRow : class
        {
            TRow? first = null;
            await foreach (var row in rows)
            {
                if (first != null)
                {
                    throw new DataConsistencyException($"Expected a single row, but more than row was returned.");
                }

                first = row;
            }

            if (first == null)
            {
                throw new DataConsistencyException($"Expected a row, but none were returned.");
            }

            return first;
        }
    }
}
