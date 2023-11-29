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

        PrintObserver printObserver = new PrintObserver();
        NumberObserver numberObserver = new NumberObserver();
        Company company;

        [ObservableProperty]
        ObservableCollection<String> employees;

        [ObservableProperty]
        bool isEmployeePicked = true;

        [ObservableProperty]
        bool isDepartmentPicked;

        [ObservableProperty]
        bool isEmployeeListPicked;

        [ObservableProperty]
        bool isDepartmentListPicked;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string departmentName;

        [ObservableProperty]
        DateTime startOfWork;

        [ObservableProperty]
        string messageArea;

        [RelayCommand]
        void AddEmployee()
        {
            Employee employee = new Employee { Name = Name, StartOfWork = StartOfWork };
            bool isDepartmentExists = company.MainDepartment.IsDepartmentExsists(DepartmentName);
            if (isDepartmentExists)
            {
                employee.Department = company.MainDepartment.FindDepartment(DepartmentName);
                company.MainDepartment.AddEntity(employee);
                Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
            }
            else
            {
                MessageArea = "Department not existing, add it first!";
            }
            MessageAreaUpdate();
        }

        [RelayCommand]
        void AddDepartment()
        {
            bool isDepartmentExists = company.MainDepartment.IsDepartmentExsists(Name);
            if (isDepartmentExists)
            {
                MessageArea = "Department already exists";
            }
            else
            {
                Department department = new Department(company.MainDepartment.FindDepartment(DepartmentName)){ Name = Name };
                company.MainDepartment.AddEntity(null, department);
                Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
            }
            MessageAreaUpdate();
        }

        private void MessageAreaUpdate()
        {
            if (company.MainDepartment.NotificationData != null)
            {
                company.Notify();
                MessageArea = $"{printObserver.PrintData()}\n\n{numberObserver.PrintOverFlowNumber}";
            }
            else
            {
                MessageArea = string.Empty;
            }
        }
        public MainViewModel()
        {
            company = new Company();
            company.Subscribe(printObserver);
            company.Subscribe(numberObserver);
            Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
        }
    }
}
