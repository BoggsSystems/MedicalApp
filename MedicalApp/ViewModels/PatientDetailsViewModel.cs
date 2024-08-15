
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System.Windows.Input;
using NoahMedical.Core.Models;
using NoahMedical.Core.Services;
using NoahMedical.Events;

namespace NoahMedical.ViewModels
{
    public class PatientDetailsViewModel : BindableBase
    {
        private readonly IPatientService _patientService;
        private readonly IEventAggregator _eventAggregator;
        private Patient _selectedPatient;

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }

        public ICommand ViewScanReportCommand { get; }
        public ICommand BackToListCommand { get; }

        public PatientDetailsViewModel(IPatientService patientService, IEventAggregator eventAggregator)
        {
            _patientService = patientService;
            _eventAggregator = eventAggregator;

            ViewScanReportCommand = new DelegateCommand<ScanData>(OnViewScanReport);
            BackToListCommand = new DelegateCommand(OnBackToList);

            // Subscribe to events to receive the selected patient data
            _eventAggregator.GetEvent<SelectedPatientChangedEvent>().Subscribe(OnSelectedPatientChanged);
        }

        private void OnSelectedPatientChanged(Patient patient)
        {
            SelectedPatient = patient;
        }

        private void OnViewScanReport(ScanData scan)
        {
            if (scan != null)
            {
                // Pass scan details as necessary
                _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("ScanReportScreen");
            }
        }

        private void OnBackToList()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("PatientListScreen");
        }
    }
}
