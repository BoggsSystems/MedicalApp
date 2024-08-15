using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for DashboardScreen.xaml
    /// </summary>
    public partial class DashboardScreen : UserControl
    {
        public DashboardScreen(DashboardViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
