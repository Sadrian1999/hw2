using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public class NumberObserver : BaseCompanyObserver
    {
        public int PrintOverFlowNumber()
        {
            return _overFlowNumber - _department.CalculateSum();
        }
    }
}
