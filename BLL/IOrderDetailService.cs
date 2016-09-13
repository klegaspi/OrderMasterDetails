using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();

        IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int orderID);

        OrderDetail GetOrderDetailsByID(int productID, int orderID);

        void AddOrderDetails(OrderDetail entity);

        void EditOrderDetails(OrderDetail entity);

        void DeleteOrderDetails(int productID, int orderID);

        void DeleteOrderDetails(int orderID);
    }
}
