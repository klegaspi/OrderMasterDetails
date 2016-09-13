using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository = null;

        public OrderService()
        {

        }

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Models.Order> GetOrdersByCustomerID(int customerID)
        {
            return _repository.GetBy(m=>m.CustomerID == customerID);
        }

        public Models.Order GetOrdersByID(int orderID)
        {
            return _repository.GetBy(m => m.OrderID == orderID).SingleOrDefault();
        }

        public void AddOrder(Models.Order entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void EditOrder(Models.Order entity)
        {
            _repository.Edit(entity);
        }

        public void DeleteOrder(int orderID)
        {
            var order = _repository.GetBy(m => m.OrderID == orderID).SingleOrDefault();

            if (order != null)
                _repository.Delete(order);
        }
    }
}
