using System.Windows.Controls;
using NoahMedical.ViewModels;

namespace NoahMedical.Screens
{
    /// <summary>
    /// Interaction logic for UserListScreen.xaml
    /// </summary>
    public partial class UserListScreen : UserControl
    {
        public UserListScreen(UserListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
