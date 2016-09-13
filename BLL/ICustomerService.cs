using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();

        IEnumerable<Customer> GetCustomersByName(string name);

        Customer GetCustomersByID(int customerID);

        void AddCustomer(Customer entity);

        void EditCustomer(Customer entity);

        void DeleteCustomer(int customerID);        
    }
}
