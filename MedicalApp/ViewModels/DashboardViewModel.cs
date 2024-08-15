// DashboardViewModel.cs
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoahMedical.Core.Models;
using NoahMedical.Core.Services;
using NoahMedical.Events;

namespace NoahMedical.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private int _activeUsersCount;
        private int _scansCompletedCount;
        private int _pendingTasksCount;
        private ObservableCollection<Notification> _notifications;

        public int ActiveUsersCount
        {
            get => _activeUsersCount;
            set => SetProperty(ref _activeUsersCount, value);
        }

        public int ScansCompletedCount
        {
            get => _scansCompletedCount;
            set => SetProperty(ref _scansCompletedCount, value);
        }

        public int PendingTasksCount
        {
            get => _pendingTasksCount;
            set => SetProperty(ref _pendingTasksCount, value);
        }

        public ObservableCollection<Notification> Notifications
        {
            get => _notifications;
            set => SetProperty(ref _notifications, value);
        }

        public ICommand NavigateToUserManagementCommand { get; }
        public ICommand NavigateToPatientListCommand { get; }
        public ICommand NavigateToReportsCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }

        public DashboardViewModel(IEventAggregator eventAggregator, IDashboardService dashboardService)
        {
            _eventAggregator = eventAggregator;

            NavigateToUserManagementCommand = new DelegateCommand(OnNavigateToUserManagement);
            NavigateToPatientListCommand = new DelegateCommand(OnNavigateToPatientList);
            NavigateToReportsCommand = new DelegateCommand(OnNavigateToReports);
            NavigateToSettingsCommand = new DelegateCommand(OnNavigateToSettings);

            LoadDashboardData(dashboardService);
        }

        private void LoadDashboardData(IDashboardService dashboardService)
        {
            ActiveUsersCount = dashboardService.GetActiveUsersCount();
            ScansCompletedCount = dashboardService.GetScansCompletedCount();
            PendingTasksCount = dashboardService.GetPendingTasksCount();
            Notifications = new ObservableCollection<Notification>(dashboardService.GetNotifications());
        }

        private void OnNavigateToUserManagement()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("UserListScreen");
        }

        private void OnNavigateToPatientList()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("PatientListScreen");
        }

        private void OnNavigateToReports()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("ReportsScreen");
        }

        private void OnNavigateToSettings()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("SettingsScreen");
        }
    }
}
