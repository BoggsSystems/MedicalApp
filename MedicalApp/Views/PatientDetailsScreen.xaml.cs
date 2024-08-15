using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for PatientDetailsScreen.xaml
    /// </summary>
    public partial class PatientDetailsScreen : UserControl
    {
        public PatientDetailsScreen(PatientDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
