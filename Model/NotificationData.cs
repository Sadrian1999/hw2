using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public class NotificationData
    {
        private int _overFlowNumber;
        private List<Employee> _employees = new();
        private List<Department> _departments = new();

        public int OverFlowNumber { get => _overFlowNumber; }
        public List<Employee> Employees { get => _employees; }
        public List<Department> Departments { get => _departments; }

        public NotificationData(int overFlowNumber, Department department = null, Employee employee = null)
        {
            _overFlowNumber = overFlowNumber;
            _employees.Add(employee);
            _departments.Add(department);
        }

        public NotificationData(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null)
        {
            _overFlowNumber = overFlowNumber;
            _employees.AddRange(employees);
            _departments.AddRange(departments);
        }
    }
}
