using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HW2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.ViewModel;

public partial class CreateDepartmentViewModel : ObservableObject
{
    [ObservableProperty]
    string departmentName;

    [ObservableProperty]
    string parentPepartment;

    [ObservableProperty]
    int maxNumber;

    [ObservableProperty]
    string employeeName;

    [ObservableProperty]
    DateTime startOfWork;

    [ObservableProperty]
    ObservableCollection<Employee> employees;

    public CreateDepartmentViewModel()
    {
        Employees = new ObservableCollection<Employee>();
    }

    [RelayCommand]
    void Add()
    {
        Department department = new(null) { Name = DepartmentName, MaxNumberOfEmployees = MaxNumber };
        Employee employee = new() { Department = department, Name = EmployeeName, StartOfWork = StartOfWork };
        Employees.Add(employee);
        Employees = new ObservableCollection<Employee>();
    }

    [RelayCommand]
    void Remove()
    {

    }

    [RelayCommand]
    void Save()
    {

    }
}
