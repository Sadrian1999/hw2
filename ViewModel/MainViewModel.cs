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
        Department department;

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
            Employees.Add(EmployeeName);
        }

        [RelayCommand]
        void AddDepartment()
        {

        }
        public MainViewModel()
        {
            Employees = new ObservableCollection<String>();
        }
    }
}
