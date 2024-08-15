using Prism.Events;
using System.Windows.Controls; // For UserControl
using NoahMedical.Core.Events;
using MedicalApp.Core.Services;

namespace NoahMedical.Core.Services
{
    public class ScreenManager : IScreenManager
    {
        private readonly IEventAggregator _eventAggregator;
        private UserControl _currentScreen;

        public ScreenManager(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<NavigationEvent>().Subscribe(Navigate);
        }

        public void NavigateTo(string screenKey)
        {
            _eventAggregator.GetEvent<NavigationEvent>().Publish(screenKey);
        }

        private void Navigate(string viewName)
        {
            // Logic to switch views based on the viewName
            // This would typically involve finding the view in a dictionary or factory and setting it as the current screen
            // For simplicity, assuming MainWindow handles this
            switch (viewName)
            {
                case "PatientView":
                    _currentScreen = new PatientView(); // Assuming these UserControls exist
                    break;
                case "UserView":
                    _currentScreen = new UserView();
                    break;
                // add other cases as necessary
            }

            // Assuming MainWindow has a method to change the displayed screen
            MainWindow.Instance.ChangeScreen(_currentScreen);
        }
    }
}
