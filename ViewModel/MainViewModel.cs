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
        List<Employee> employeesToAdd = new List<Employee>();
        List<Department> departmentsToAdd = new List<Department>();


        [ObservableProperty]
        ObservableCollection<string> employees;

        [ObservableProperty]
        bool isEmployeePicked = true;

        [ObservableProperty]
        bool isDepartmentPicked;

        [ObservableProperty]
        bool isEmployeeListPicked;

        [ObservableProperty]
        bool isDepartmentListPicked;

        [ObservableProperty]
        int max;

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
                MessageArea = $"Added {employee.Name}";
            }
            else
            {
                MessageArea = "Department not existing, add it first!";
            }
            MessageAreaUpdate();
        }

        [RelayCommand]
        void AddEmployees()
        {
            Employee employee = new Employee { Name = Name, StartOfWork = StartOfWork };
            bool isDepartmentExists = company.MainDepartment.IsDepartmentExsists(DepartmentName);
            if (isDepartmentExists)
            {
                employee.Department = company.MainDepartment.FindDepartment(DepartmentName);
                employeesToAdd.Add(employee);
                MessageArea += $"Added {employee.Name} to {employee.Department.Name}\nStart of Work {employee.StartOfWork}\n";
            }

        }

        [RelayCommand]
        void ConfirmAddingEmployees()
        {
            company.MainDepartment.AddEntity(employeesToAdd);
            Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
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
                Department department = new Department(company.MainDepartment.FindDepartment(DepartmentName)){ Name = Name, MaxNumberOfEmployees = Max};
                company.MainDepartment.AddEntity(department);
                Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
            }
            MessageAreaUpdate();
        }

        [RelayCommand]
        void AddDepartments()
        {
            bool isDepartmentExists = company.MainDepartment.IsDepartmentExsists(Name);
            if (isDepartmentExists)
            {
                MessageArea = "Department already exists";
            }
            else
            {
                Department department = new Department(company.MainDepartment.FindDepartment(DepartmentName)){ Name = Name, MaxNumberOfEmployees = Max};
                departmentsToAdd.Add(department);
                MessageArea += $"Added {department.Name}, Max employees here :{department.MaxNumberOfEmployees}\n";
            }

        }

        [RelayCommand]
        void ConfirmAddingDepartments()
        {
            company.MainDepartment.AddEntity(departmentsToAdd);
            Employees = new ObservableCollection<String>(company.MainDepartment.ListEntities());
            MessageAreaUpdate();
        }


        private void MessageAreaUpdate()
        {
            if (company.MainDepartment.NotificationData != null)
            {
                company.Notify();
                MessageArea = $"{printObserver.PrintData()}\n\n{numberObserver.PrintOverFlowNumber}";
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
