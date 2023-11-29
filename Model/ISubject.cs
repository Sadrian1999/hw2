using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public interface ISubject
    {
        void Notify(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null);
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
    }
}
