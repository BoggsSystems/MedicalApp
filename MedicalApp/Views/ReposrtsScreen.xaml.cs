using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for ReportsScreen.xaml
    /// </summary>
    public partial class ReportsScreen : UserControl
    {
        public ReportsScreen(ReportsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
