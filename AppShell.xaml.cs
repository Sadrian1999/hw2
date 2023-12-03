using HW2.View;

namespace HW2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateDepartment), typeof(CreateDepartment));
        }
    }
}