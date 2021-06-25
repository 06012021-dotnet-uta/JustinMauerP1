using Microsoft.EntityFrameworkCore;
using AppStore = BusinessLayer.App;
using System;
using RepositoryLayer;
using Xunit;
using ModelsLibrary;
using System.Threading.Tasks;
using System.Linq;

namespace App.Tests
{
    // Create in memory database
    
    public class UnitTest1
    {
        DbContextOptions<AppStoreDb> options = new DbContextOptionsBuilder<AppStoreDb>().UseInMemoryDatabase(databaseName: "TestDb").Options;


        [Fact]
        public async Task RegisterCustomer()
        {
            // Arrange
            // Create a player to insert into the inmemory db
            Customer cust = new Customer()
            {
                FirstName = "John",
                LastName = "Jacob",
                PhoneNumber = "(123) 456 - 7890",
                Email = "jj@email.com",
                City = "Portland",
                State = "Oregon",
                Password = "pass123",
                Store = 10,
                CarYear= 2020,
                CarMake = "Honda",
                CarModel = "Civic"
            };

            Customer cust1;

            using (var context = new AppStoreDb(options))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Customers.Add(cust);
                context.SaveChanges();

                cust1 = context.Customers.FirstOrDefault();

            }

            bool result = false;

            // Act
            // Instantiate in-memory database
            using (var context = new AppStoreDb(options))
            {
                // verify that the db was deleted and
                // create a new instants
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore autoStore = new AppStore(context);
                
                result = await autoStore.RegisterCustomerAsync(cust);


                context.SaveChanges();

            // Assert

                int count = await context.Customers.CountAsync();
                var c = context.Customers.FirstOrDefault();
                
                Assert.True(result);
                Assert.Equal(1, count);
                Assert.NotNull(c);
                Assert.Equal(cust1, cust);
                Assert.Contains(cust, context.Customers);
                
            }

        }
    }
}
