using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HW2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.ViewModel
{
    partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<String> employees;

        [ObservableProperty]
        Department mainDepartment;

        [ObservableProperty]
        bool isEmployeePicked = true;

        [ObservableProperty]
        bool isDepartmentPicked;

        [ObservableProperty]
        string employeeName;

        [ObservableProperty]
        string departmentName;

        [ObservableProperty]
        DateTime startOfWork;

        [RelayCommand]
        void AddEmployee()
        {
            Employee employee = new Employee { Name = EmployeeName, StartOfWork = StartOfWork };
            MainDepartment.AddEntity(new List<Employee> { employee });
        }

        [RelayCommand]
        void AddDepartment()
        {

        }
        public MainViewModel()
        {
            MainDepartment = new Department();
            Employees = new ObservableCollection<String>(MainDepartment.ListEntities());
        }
    }
}
