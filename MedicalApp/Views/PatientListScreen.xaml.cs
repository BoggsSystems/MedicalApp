using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for PatientListScreen.xaml
    /// </summary>
    public partial class PatientListScreen : UserControl
    {
        public PatientListScreen(PatientListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
