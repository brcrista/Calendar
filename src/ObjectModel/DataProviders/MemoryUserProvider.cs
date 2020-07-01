using System;
using System.Collections.Generic;
using System.Linq;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class MemoryUserProvider : IUserProvider
    {
        public User GetUser(int id)
        {
            return new User
            {
                Id = id,
                DisplayName = "Jane Doe",
                Account = new Account
                {
                    Id = 1,
                    Email = "jane.doe@email.com",
                    Password = "1234"
                }
            };
        }

        public IEnumerable<Event> GetEvents(int id, int? hostId, bool? hasAccepted)
        {
            IEnumerable<Event> events = new[]
            {
                new Event
                {
                    Id = 1,
                    Title = "Some party",
                    Start = DateTime.Today + TimeSpan.FromDays(1),
                    End = DateTime.Today + TimeSpan.FromDays(2),
                    Location = "Durham, NC",
                    Owner = new User
                    {
                        Id = 10,
                        DisplayName = "Joe Schmoe"
                    }
                },
                new Event
                {
                    Id = 2,
                    Title = "My party",
                    Start = DateTime.Today + TimeSpan.FromDays(1),
                    End = DateTime.Today + TimeSpan.FromDays(2),
                    Location = "Raleigh, NC",
                    Owner = new User
                    {
                        Id = id,
                        DisplayName = "Jane Doe"
                    }
                },
                new Event
                {
                    Id = 3,
                    Title = "A picnic",
                    Start = DateTime.Today + TimeSpan.FromDays(1),
                    End = DateTime.Today + TimeSpan.FromDays(2),
                    Location = "Raleigh, NC",
                    Owner = new User
                    {
                        Id = 10,
                        DisplayName = "Joe Schmoe"
                    }
                }
            };

            if (hostId != null)
            {
                events = events.Where(e => e.Owner?.Id == hostId);
            }

            if (hasAccepted != null)
            {
                if (hasAccepted == true)
                {
                    events = events.Where(e => e.Id != 3);
                }
                else
                {
                    events = events.Where(e => e.Id == 3);
                }
            }

            return events;
        }

        public IEnumerable<User> GetContacts(int id)
        {
            return new[]
            {
                new User
                {
                    Id = 10,
                    DisplayName = "Joe Schmoe"
                }
            };
        }
    }
}
