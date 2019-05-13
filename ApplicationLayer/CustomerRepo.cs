using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class CustomerRepo
    {
        private List<Customer> customers = new List<Customer>();

        public void AddToCustomerList(Customer customer)
        {
            customers.Add(customer);
        }


    }
}
