using System;
using System.Collections.Generic;
using System.Linq;
using LunchService.Controllers;
using Marten;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace LunchService.Accessors
{
    public class LunchAccessor : ILunchAccessor
    {
        private readonly string _connectionString;

        public LunchAccessor(IConnectionStringProvider connectionProvider)
        {
            _connectionString = connectionProvider.GetConnectionString();
        }

        private IDocumentStore Store
        {
            get
            {
                var store = DocumentStore.For(_ =>
                {
                    _.Connection(_connectionString);
                });
                return store;
            }
        }

        public Lunch GetByLocation(string location)
        {
            using (var session = Store.QuerySession())
            {
                return session.Query<Lunch>().FirstOrDefault(lunch => lunch.Location == location);
            }
        }

        public Lunch CreateNewLunch(IEnumerable<Friend> friends, string location)
        {
            var lunch = new Lunch
            {
                Location = location,
                Friends = friends
            };

            using (var session = Store.OpenSession())
            {
                session.Store(lunch);

                session.SaveChanges();
            }

            return lunch;
        }
    }
}
