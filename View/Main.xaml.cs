using HW2.ViewModel;

namespace HW2.View;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}