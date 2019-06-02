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
        public Customer GetCustomerAtIndex(int index)
        {
            Customer customer = new Customer();

            customer = customers.ToArray().ElementAt(index);

            return customer;
        }
    }
}