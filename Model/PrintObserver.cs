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
            if (_departments != null)
            {
                _departments.Where(x => x != null).ToList().ForEach(x => str += $"{x.Name}; ");         
            }
            else 
            {
                _employees.ForEach(x => str += $"{x.Name}; ");
            }
            return str;
        }
    }
}
