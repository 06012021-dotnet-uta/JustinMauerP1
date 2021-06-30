using Microsoft.EntityFrameworkCore;
using AppStore = BusinessLayer.App;
using System;
using RepositoryLayer;
using Xunit;
using ModelsLibrary;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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

        [Fact]
        public async Task CustomerListAsync()
        {
            // Arrange

            bool cust1Reg = false;
            bool cust2Reg = false;
            int count = 0;
            
            // Create a customer to insert into the inmemory db
            Customer cust1 = new Customer()
            {
                FirstName = "John",
                LastName = "Jacob",
                PhoneNumber = "(123) 456 - 7890",
                Email = "jj@email.com",
                City = "Portland",
                State = "Oregon",
                Password = "pass123",
                Store = 10,
                CarYear = 2020,
                CarMake = "Honda",
                CarModel = "Civic"
            };

            // Create a player to insert into the inmemory db
            Customer cust2 = new Customer()
            {
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "(123) 456 - 7890",
                Email = "js@email.com",
                City = "Sacramento",
                State = "California",
                Password = "pass123",
                Store = 10,
                CarYear = 2020,
                CarMake = "Lexus",
                CarModel = "Rx"
            };


            // Act

            // Instantiate in memory database
            using (var context = new AppStoreDb(options))
            {
                // verify that the db was deleted and
                // create a new instants
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore appStore = new AppStore(context);

                cust1Reg = await appStore.RegisterCustomerAsync(cust1);
                cust2Reg = await appStore.RegisterCustomerAsync(cust2);

                await context.SaveChangesAsync();

                count = await context.Customers.CountAsync();
                List<Customer> customerList = await context.Customers.ToListAsync();

                // Assert
                Assert.True(cust1Reg);
                Assert.True(cust2Reg);
                Assert.Equal(2, count);
                Assert.Contains(cust1, context.Customers);
                Assert.Contains(cust2, context.Customers);
                
                Assert.NotNull(customerList);
                Assert.Equal(customerList.Count, count);


            }


        }

        [Fact]
        public async Task FindCustomerAsync()
        {
            // Arrange


            // Act


            // Assert


        }

    }
}
