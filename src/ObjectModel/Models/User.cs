using System.Collections.Generic;

namespace Calendar.ObjectModel.Models
{
    public sealed class User
    {
        public long Id { get; set; }

        public string? DisplayName { get; set; }

        /// <remarks>
        /// This is left as an ID because, for security, it should not usually be retrieved.
        /// A null account ID may represent a deleted account.
        /// </remarks>
        public long? AccountId { get; set; }

        public IList<Event> Events { get; set; } = new List<Event>();
    }
}