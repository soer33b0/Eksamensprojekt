using DomainLayer;
using System.Collections.Generic;

namespace ApplicationLayer
{
    public class EmployeeRepo
    {
        Controller controller = new Controller();

        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void UpdateEmployeeList()
        {
            employees = controller.GetEmployeeList();
        }
    }
}
