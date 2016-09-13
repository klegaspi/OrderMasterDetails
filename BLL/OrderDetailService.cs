using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepository<OrderDetail> _repository = null;

        public OrderDetailService()
        {

        }

        public OrderDetailService(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.OrderDetail> GetAllOrderDetails()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Models.OrderDetail> GetOrderDetailsByOrderID(int orderID)
        {
            return _repository.GetBy(m=>m.OrderID == orderID);
        }

        public Models.OrderDetail GetOrderDetailsByID(int productID, int orderID)
        {
            return _repository.GetBy(m => m.OrderID == orderID && m.ProductID == productID).SingleOrDefault();
        }

        public void AddOrderDetails(Models.OrderDetail entity)
        {
            _repository.Add(entity);
        }

        public void EditOrderDetails(Models.OrderDetail entity)
        {
            _repository.Edit(entity);
        }

        public void DeleteOrderDetails(int productID, int orderID)
        {
            var orderDetail = _repository.GetBy(m => m.ProductID == productID && m.OrderID == orderID).SingleOrDefault();

            if (orderDetail != null)
                _repository.Delete(orderDetail);
        }

        public void DeleteOrderDetails(int orderID)
        {
            var orderDetails = _repository.GetBy(m => m.OrderID == orderID);

            if (orderDetails != null)
                _repository.DeleteRange(orderDetails);
        }
    }
}
