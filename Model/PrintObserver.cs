using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public class PrintObserver : BaseCompanyObserver
    {
        public string PrintData()
        {
            string str = "";
            if (_department != null)
            {
                str += $"{_department.Name}";
            }
            else 
            { 
               str += $"{_employee.Name}";
            }
            return str;
        }
    }
}
