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

            // Create a customer to insert into the inmemory db
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

            bool cust1Reg = false;
            bool cust2Reg = false;

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

            // Create a customer to insert into the inmemory db
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
            using (var context = new AppStoreDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                AppStore appStore = new AppStore(context);

                cust1Reg = await appStore.RegisterCustomerAsync(cust1);
                cust2Reg = await appStore.RegisterCustomerAsync(cust2);

                await context.SaveChangesAsync();

                // Permiate different outputs for searching Customer1
                Customer cust1BothRight = await appStore.FindCustomerAsync(cust1.LastName, cust1.Password);
                Customer cust1LastRight = await appStore.FindCustomerAsync(cust1.LastName, "WrongPassword");
                Customer cust1PassRight = await appStore.FindCustomerAsync("WrongLastName", cust1.Password);
                Customer cust1BothWrong = await appStore.FindCustomerAsync("WrongLastName", "WrongPassword");



                // Permiate different outputs for searching Customer1
                Customer cust2BothRight = await appStore.FindCustomerAsync(cust2.LastName, cust2.Password);
                Customer cust2LastRight = await appStore.FindCustomerAsync(cust2.LastName, "WrongPassword");
                Customer cust2PassRight = await appStore.FindCustomerAsync("WrongLastName", cust2.Password);
                Customer cust2BothWrong = await appStore.FindCustomerAsync("WrongLastName", "WrongPassword");

                // Assert
                Assert.True(cust1Reg);
                Assert.True(cust2Reg);

                Assert.NotNull(cust1BothRight);
                Assert.Null(cust1BothWrong);
                Assert.Null(cust1LastRight);
                Assert.Null(cust1LastRight);

                Assert.NotNull(cust2BothRight);
                Assert.Null(cust2BothWrong);
                Assert.Null(cust2LastRight);
                Assert.Null(cust2LastRight);
            }

        }

        [Fact]
        public async Task StoreListAsync()
        {
            // Arrange
            Store store1 = new Store()
            {
                State = "Ga",
                City = "Atlanta",
                PhoneNumber = "(123) 456 - 7890",
                
            };

            Store store2 = new Store()
            {
                State = "Az",
                City = "Pheonix",
                PhoneNumber = "(321) 456 - 7890",

            };

            Store store3 = new Store()
            {
                State = "Or",
                City = "Portland",
                PhoneNumber = "(213) 456 - 7890",

            };

            

            // Act
            using(var context = new AppStoreDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore appStore = new AppStore(context);

                await context.Stores.AddAsync(store1);
                await context.Stores.AddAsync(store2);
                await context.Stores.AddAsync(store3);

                await context.SaveChangesAsync();

                List<Store> storeList = await appStore.StoreListAsync();
                int count = await context.Stores.CountAsync();

                // Assert

                Assert.NotNull(context.Stores);
                Assert.NotNull(storeList);

                Assert.Equal(count, storeList.Count);

                Assert.Contains(store1, storeList);
                Assert.Contains(store2, storeList);
                Assert.Contains(store3, storeList);

            }
        }

        [Fact]
        public async Task StoreItemListAsync()
        {
            // Arrange
            Item item1 = new Item()
            {   
                Part = "TestPart1",
                PartNumber = 100,
                PartDesc = "Test Part Description",
                Price = (decimal)9.99,
                Quantity = 1,
                Location = "Test",
                Store = 1
            };

            Item item2 = new Item()
            {
                Part = "TestPart2",
                PartNumber = 200,
                PartDesc = "Test Part Description",
                Price = (decimal)8.99,
                Quantity = 2,
                Location = "Test",
                Store = 2
            };

            Item item2b = new Item()
            {
                Part = "TestPart2b",
                PartNumber = 201,
                PartDesc = "Test Part Description",
                Price = (decimal)15.99,
                Quantity = 1,
                Location = "Test",
                Store = 2
            };

            Item item3 = new Item()
            {
                Part = "TestPart3",
                PartNumber = 300,
                PartDesc = "Test Part Description",
                Price = (decimal)12.99,
                Quantity = 3,
                Location = "Test",
                Store = 3
            };

            Item item3b = new Item()
            {
                Part = "TestPart3b",
                PartNumber = 301,
                PartDesc = "Test Part Description",
                Price = (decimal)10.99,
                Quantity = 2,
                Location = "Test",
                Store = 3
            };

            Item item3c = new Item()
            {
                Part = "TestPart3c",
                PartNumber = 302,
                PartDesc = "Test Part Description",
                Price = (decimal)25.99,
                Quantity = 4,
                Location = "Test",
                Store = 3
            };

            Store store1 = new Store()
            {
                State = "Ga",
                City = "Atlanta",
                PhoneNumber = "(123) 456 - 7890",

            };

            Store store2 = new Store()
            {
                State = "Az",
                City = "Pheonix",
                PhoneNumber = "(321) 456 - 7890",

            };

            Store store3 = new Store()
            {
                State = "Or",
                City = "Portland",
                PhoneNumber = "(213) 456 - 7890",

            };

            // Act
            using (var context = new AppStoreDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore appStore = new AppStore(context);

                await context.Items.AddAsync(item1);
                await context.Items.AddAsync(item2);
                await context.Items.AddAsync(item2b);
                await context.Items.AddAsync(item3);
                await context.Items.AddAsync(item3b);
                await context.Items.AddAsync(item3c);

                await context.Stores.AddAsync(store1);
                await context.Stores.AddAsync(store2);
                await context.Stores.AddAsync(store3);

                await context.SaveChangesAsync();

                List<Item> itemList1 = await appStore.ItemListAsync(store1);
                List<Item> itemList2 = await appStore.ItemListAsync(store2);
                List<Item> itemList3 = await appStore.ItemListAsync(store3);

                int count1 = await context.Items.Where(x => x.Store == 1).CountAsync();
                int count2 = await context.Items.Where(x => x.Store == 2).CountAsync();
                int count3 = await context.Items.Where(x => x.Store == 3).CountAsync();


                // Assert
                // Assert items are in database
                Assert.NotNull(itemList1);
                Assert.NotNull(itemList2);
                Assert.NotNull(itemList3);

                Assert.Contains(item1, itemList1);
                Assert.Contains(item2, itemList2);
                Assert.Contains(item2b, itemList2);
                Assert.Contains(item3, itemList3);
                Assert.Contains(item3b, itemList3);
                Assert.Contains(item3c, itemList3);

                Assert.Equal(count1, itemList1.Count);
                Assert.Equal(count2, itemList2.Count);
                Assert.Equal(count3, itemList3.Count);


            }

            using (var context = new AppStoreDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore appStore = new AppStore(context);

                await context.Items.AddAsync(item1);
                await context.Items.AddAsync(item2);
                await context.Items.AddAsync(item2b);
                await context.Items.AddAsync(item3);
                await context.Items.AddAsync(item3b);
                await context.Items.AddAsync(item3c);

                await context.Stores.AddAsync(store1);
                await context.Stores.AddAsync(store2);
                await context.Stores.AddAsync(store3);

                await context.SaveChangesAsync();

                List<Item> itemList1 = await appStore.StoreItemListAsync(store1.StoreId);
                List<Item> itemList2 = await appStore.StoreItemListAsync(store2.StoreId);
                List<Item> itemList3 = await appStore.StoreItemListAsync(store3.StoreId);

                int count1 = await context.Items.Where(x => x.Store == 1).CountAsync();
                int count2 = await context.Items.Where(x => x.Store == 2).CountAsync();
                int count3 = await context.Items.Where(x => x.Store == 3).CountAsync();


                // Assert
                // Assert items are in database
                Assert.NotNull(itemList1);
                Assert.NotNull(itemList2);
                Assert.NotNull(itemList3);

                Assert.Contains(item1, itemList1);
                Assert.Contains(item2, itemList2);
                Assert.Contains(item2b, itemList2);
                Assert.Contains(item3, itemList3);
                Assert.Contains(item3b, itemList3);
                Assert.Contains(item3c, itemList3);

                Assert.Equal(count1, itemList1.Count);
                Assert.Equal(count2, itemList2.Count);
                Assert.Equal(count3, itemList3.Count);


            }

        }

        [Fact]
        public async Task ChangeStore()
        {
            // Arrange
            Store store1 = new Store()
            {
                State = "Ga",
                City = "Atlanta",
                PhoneNumber = "(123) 456 - 7890",

            };

            Store store2 = new Store()
            {
                State = "Az",
                City = "Pheonix",
                PhoneNumber = "(321) 456 - 7890",

            };

            Customer cust1 = new Customer()
            {
                FirstName = "John",
                LastName = "Jacob",
                PhoneNumber = "(123) 456 - 7890",
                Email = "jj@email.com",
                City = "Portland",
                State = "Oregon",
                Password = "pass123",
                Store = 1,
                CarYear = 2020,
                CarMake = "Honda",
                CarModel = "Civic"
            };

            bool storeChanged = false;

            // Act
            using (var context = new AppStoreDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AppStore appStore = new AppStore(context);

                await context.Customers.AddAsync(cust1);
                await context.Stores.AddAsync(store1);
                await context.Stores.AddAsync(store2);

                await context.SaveChangesAsync();

                // Assert
                Assert.Equal(cust1.Store, store1.StoreId);

                storeChanged = await appStore.ChangeStore(store2, cust1);

                Assert.True(storeChanged);

                Assert.Equal(cust1.Store, store2.StoreId);

            }

        }

    }
}
