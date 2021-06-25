using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibrary;

namespace RepositoryLayer
{
    public class AppStoreDb : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Stores { get; set; }

        // No arg constructor
        public AppStoreDb()
        {

        }
        
        
        public AppStoreDb(DbContextOptions options) : base(options) { }

        // Override OnConfiguring()
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // check if the options have already been configured
           /* if(!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AppStoreDb;Trusted_Connection=True;");
            }*/
        }

        // override OnConfiguring()

    }
}
