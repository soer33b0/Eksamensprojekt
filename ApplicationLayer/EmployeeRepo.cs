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
        private List<Employee> ListEmployee;

        public EmployeeRepo()
        {
            ListEmployee = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            ListEmployee.Add(employee);
        }
    }
}
