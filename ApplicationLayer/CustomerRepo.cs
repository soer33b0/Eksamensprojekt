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
        Controller controller = new Controller();

        private List<Customer> customers = new List<Customer>();
        
        public void UpdateCustomerList()
        {
            customers = controller.GetCustomerList();
            customers.Sort();
        }

        public List<Customer> GetCustomerList()
        {
            UpdateCustomerList();
            return customers;
        }

        public List<string> GetCustomerNames()
        {
            List<string> customerNames = new List<String>();

            foreach (Customer customer in customers)
            {
                customerNames.Add(customer.CustomerName);
            }
     
            return customerNames;
        }
    }
}
