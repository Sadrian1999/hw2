using HW2.ViewModel;

namespace HW2.View;

public partial class CreateDepartment : ContentPage
{
	public CreateDepartment(CreateDepartmentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}