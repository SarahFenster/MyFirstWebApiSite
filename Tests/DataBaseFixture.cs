using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DatabaseFixture : IDisposable
    {
        public ClothesShop326023306Context Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<ClothesShop326023306Context>()
                .UseSqlServer("Server=srv2\\pupils;Database=Sarah_Tests;Trusted_Connection=True;")
                .Options;
            Context = new ClothesShop326023306Context(options, null);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
