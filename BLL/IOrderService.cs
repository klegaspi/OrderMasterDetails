using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();

        IEnumerable<Order> GetOrdersByCustomerID(int customerID);

        Order GetOrdersByID(int orderID);

        void AddOrder(Order entity);

        void EditOrder(Order entity);

        void DeleteOrder(int orderID);        
    }
}
