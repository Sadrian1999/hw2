using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public abstract class BaseCompanyObserver : IObserver
    {
        protected int _overFlowNumber;
        protected Employee _employee;
        protected Department _department;
        public void Update(int overFlowNumber, Department department = null, Employee employee = null)
        {
            _overFlowNumber = overFlowNumber;
            _employee = employee;
            _department = department;
        }

    }
}
