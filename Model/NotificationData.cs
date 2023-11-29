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
        private Employee _employee;
        private Department _department;

        public int OverFlowNumber { get => _overFlowNumber; }
        public Employee Employee { get => _employee; }
        public Department Department { get => _department; }

        public NotificationData(int overFlowNumber, Department department = null, Employee employee = null)
        {
            _overFlowNumber = overFlowNumber;
            _employee = employee;
            _department = department;
        }
    }
}
