using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ProductContext()
        {            
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductContext, Configuration>()); 
            Database.SetInitializer<ProductContext>(new ProductInitializer());
        }
    }
}
