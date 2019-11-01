using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : ICustomerService
    {
		//dsds
        private readonly IRepository<Customer> _repository = null;

        public CustomerService()
        {

        }

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Models.Customer> GetCustomersByName(string name)
        {
            return _repository.GetBy(m=>m.Name == name);
        }

        public Customer GetCustomersByID(int customerID)
        {
            return _repository.GetBy(m => m.CustomerID == customerID).SingleOrDefault();
        }

        public void AddCustomer(Models.Customer entity)
        {
            _repository.Add(entity);
        }

        public void EditCustomer(Models.Customer entity)
        {
            _repository.Edit(entity);
        }

        public void DeleteCustomer(int customerID)
        {
            var customer = _repository.GetBy(m => m.CustomerID == customerID).SingleOrDefault();

            if (customer != null)
                _repository.Delete(customer);
        }
    }
}
