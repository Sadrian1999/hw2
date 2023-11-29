using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Model
{
    public class Department : IComponent, ISubject
    {
        private int _maxNumberOfEmployees;
        private string _name;
        private List<Employee> _employees = new List<Employee>();
        private List<Department> _departments = new List<Department>();
        private List<IObserver> _observers = new List<IObserver>();

        public int MaxNumberOfEmployees { get => _maxNumberOfEmployees; set => value = _maxNumberOfEmployees; }
        public string Name { get => _name; set => _name = value; }

        public void AddEntity(List<Employee> employees = null, List<Department> departments = null)
        {
            int overFlowNumber;
            if (employees != null)
            {
                overFlowNumber = CalculateSum() + employees.Count;
                if (overFlowNumber < MaxNumberOfEmployees)
                {
                    _employees.AddRange(employees);
                }
                else
                {
                    Notify(overFlowNumber, null, employees);
                }
            }
            else if (departments != null) 
            {
                overFlowNumber = CalculateSum() + departments.Sum(x => x.CalculateSum());
                if (overFlowNumber < MaxNumberOfEmployees)
                {
                    _departments.AddRange(departments);
                }
                else
                {
                    Notify(overFlowNumber, departments);
                }
            }
        }
        public void RemoveEntity(Department department = null, Employee employee = null)
        {
            if (employee != null)
            {
                if (employee != null && _employees.Contains(employee))
                {
                    _employees.Remove(employee);
                }
            }
            else if (department != null) 
            {
                if (department != null && _departments.Contains(department))
                {
                    _departments.Remove(department);
                }
            }
        }
        public List<string> ListEntities()
        {
            List<string> entities = new List<string>();
            _employees.ForEach(x => entities.Add($"Emp {x.Name}"));
            if (_departments == null)
            {
                return null;
            }
            entities.Add($"Dep{Name}");
            _departments.ForEach(x => entities.AddRange(x.ListEntities()));
            return entities;
        }
        public string GetEmployeeName(int i)
        {
            return _employees[i].Name;
        }
        public int CalculateSum()
        {
            return _employees.Count + _departments.Sum(x =>x.CalculateSum());
        }
        public void Notify(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null)
        {
            _observers.ForEach(x => x.Update(overFlowNumber, departments, employees));
        }
        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void UnSubscribe(IObserver observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }
    }
}
