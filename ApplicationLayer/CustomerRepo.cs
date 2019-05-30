using DomainLayer;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer
{
    public class CustomerRepo
    {
        Controller controller = new Controller();

        public List<Customer> customers = new List<Customer>();
        
        public void UpdateCustomerList()
        {
            customers = controller.GetCustomerList();
        }

        //public List<string> GetCustomerNames()
        //{
        //    List<string> customerNames = new List<String>();

        //    foreach (Customer customer in customers)
        //    {
        //        customerNames.Add(customer.CustomerName);
        //    }
     
        //    return customerNames;
        //}

        public Customer GetCustomerAtIndex(int index, string customerName)
        {
            Customer customer = new Customer();

            customer = customers.ToArray().ElementAt(index);

            return customer;
        }
    }
}
