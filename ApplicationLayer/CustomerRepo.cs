using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class CustomerRepo
    {
        DBController dbController = new DBController();

        private List<Customer> customers = new List<Customer>();


        public void AddToCustomerList(Customer customer)
        {
            customers.Add(customer);
        }
    }
}
