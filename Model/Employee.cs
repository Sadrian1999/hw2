using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public class Employee : IComponent
    {
        private DateTime _startOfWork;
        private string _name;
        public DateTime StartOfWork { get => _startOfWork; set => value = _startOfWork; }
        public string Name { get => _name; set => _name = value; }

        public int CalculateSum()
        {
            return 1;
        }
    }
}
