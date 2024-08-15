// UserListViewModel.cs
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NoahMedical.Core.Models;
using NoahMedical.Core.Services;
using NoahMedical.Events;

namespace NoahMedical.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        private readonly IUserService _userService;
        private readonly IEventAggregator _eventAggregator;
        private ObservableCollection<User> _users;
        private ObservableCollection<User> _filteredUsers;
        private string _searchQuery;
        private User _selectedUser;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public ObservableCollection<User> FilteredUsers
        {
            get => _filteredUsers;
            set => SetProperty(ref _filteredUsers, value);
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                SetProperty(ref _searchQuery, value);
                FilterUsers();
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand SearchCommand { get; }

        public UserListViewModel(IUserService userService, IEventAggregator eventAggregator)
        {
            _userService = userService;
            _eventAggregator = eventAggregator;

            AddUserCommand = new DelegateCommand(OnAddUser);
            EditUserCommand = new DelegateCommand<User>(OnEditUser);
            DeleteUserCommand = new DelegateCommand<User>(OnDeleteUser);
            SearchCommand = new DelegateCommand(FilterUsers);

            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await _userService.GetUsersAsync();
            Users = new ObservableCollection<User>(users);
            FilteredUsers = new ObservableCollection<User>(users);
        }

        private void FilterUsers()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredUsers = new ObservableCollection<User>(Users);
            }
            else
            {
                FilteredUsers = new ObservableCollection<User>(
                    Users.Where(u => u.Username.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase) ||
                                     u.Role.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase)));
            }
        }

        private void OnAddUser()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("AddUserScreen");
        }

        private void OnEditUser(User user)
        {
            if (user != null)
            {
                _eventAggregator.GetEvent<SelectedUserChangedEvent>().Publish(user);
                _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("EditUserScreen");
            }
        }

        private void OnDeleteUser(User user)
        {
            if (user != null)
            {
                _userService.DeleteUser(user);
                LoadUsers();
            }
        }
    }
}
