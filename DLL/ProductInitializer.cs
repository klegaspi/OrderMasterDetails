using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerID=1, Name="John Mathew"},
                new Customer { CustomerID=2, Name="Jim Parker"},
                new Customer { CustomerID=3, Name="Sophia Ran"},
                new Customer { CustomerID=4, Name="Wendi Blake"}
            };

            customers.ForEach(m => context.Customers.Add(m));

            List<Product> products = new List<Product>
            {
                new Product { ProductID=1, Name="iPhone 7" },
                new Product { ProductID=2, Name="iPhone 6s" },
                new Product { ProductID=3, Name="iPhone 6" },
                new Product { ProductID=4, Name="iPhone 5s" },
                new Product { ProductID=5, Name="iPhone 5" },
                new Product { ProductID=6, Name="iPad Mini 3" },
                new Product { ProductID=7, Name="iPad Air 2" }
            };

            products.ForEach(p => context.Products.Add(p));

            List<ProductOption> productOptions = new List<ProductOption>
            {
                new ProductOption { ProductOptionID=1, Name="Option 1", Product=products[0] },
                new ProductOption { ProductOptionID=2, Name="Option 2", Product=products[0]  },
                new ProductOption { ProductOptionID=3, Name="Option 3", Product=products[1] }
            };

            productOptions.ForEach(o => context.ProductOptions.Add(o));


            List<Order> orders = new List<Order>
            {
                new Order { Customer=customers[0], Description="Desc 1", OrderDate=DateTime.Now, OrderID=1, OrderNo="1" },
                new Order { Customer=customers[0], Description="Desc 2", OrderDate=DateTime.Now, OrderID=2, OrderNo="2" },
                new Order { Customer=customers[1], Description="Desc 3", OrderDate=DateTime.Now, OrderID=3, OrderNo="3" }                
            };

            orders.ForEach(m => context.Orders.Add(m));

            List<OrderDetail> orderDetails = new List<OrderDetail>
            {
                new OrderDetail {  Order=orders[0], Product=products[0], Quantity=10, Price=1, TotalAmount=10 },
                new OrderDetail {  Order=orders[0], Product=products[1], Quantity=2, Price=12, TotalAmount=24 },
                
                new OrderDetail {  Order=orders[1], Product=products[1], Quantity=2, Price=41, TotalAmount=82 },
                new OrderDetail {  Order=orders[1], Product=products[2], Quantity=2, Price=51, TotalAmount=102 },

                new OrderDetail {  Order=orders[2], Product=products[1], Quantity=2, Price=8, TotalAmount=16 },
                new OrderDetail {  Order=orders[2], Product=products[4], Quantity=2, Price=88, TotalAmount=176 },
                new OrderDetail {  Order=orders[2], Product=products[3], Quantity=2, Price=90, TotalAmount=180 },
            };

            orderDetails.ForEach(m => context.OrderDetails.Add(m));

            context.SaveChanges();
        }
    }
}
