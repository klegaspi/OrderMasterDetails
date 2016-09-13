using Microsoft.Practices.Unity;
using Service;
using System.Web.Http;
using Unity.WebApi;
using Repository;
using Models;

namespace WebApplication11
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductOptionService, ProductOptionService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderDetailService, OrderDetailService>();
            

            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IRepository<ProductOption>, Repository<ProductOption>>();
            container.RegisterType<IRepository<Customer>, Repository<Customer>>();
            container.RegisterType<IRepository<Order>, Repository<Order>>();
            container.RegisterType<IRepository<OrderDetail>, Repository<OrderDetail>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}