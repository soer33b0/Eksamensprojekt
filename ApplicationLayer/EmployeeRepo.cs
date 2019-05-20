using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

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
            employees.Sort();
        }

        public List<Employee> GetEmployeeList()
        {
            UpdateEmployeeList();
            return employees;
        }
    }
}
