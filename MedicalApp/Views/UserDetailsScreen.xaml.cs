using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for UserDetailsScreen.xaml
    /// </summary>
    public partial class UserDetailsScreen : UserControl
    {
        public UserDetailsScreen(UserDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
