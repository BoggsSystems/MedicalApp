
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
    public class PatientListViewModel : BindableBase
    {
        private readonly IPatientService _patientService;
        private readonly IEventAggregator _eventAggregator;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Patient> _filteredPatients;
        private string _searchQuery;
        private Patient _selectedPatient;

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set => SetProperty(ref _patients, value);
        }

        public ObservableCollection<Patient> FilteredPatients
        {
            get => _filteredPatients;
            set => SetProperty(ref _filteredPatients, value);
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                SetProperty(ref _searchQuery, value);
                FilterPatients();
            }
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }

        public ICommand AddPatientCommand { get; }
        public ICommand ViewPatientCommand { get; }
        public ICommand EditPatientCommand { get; }
        public ICommand SearchCommand { get; }

        public PatientListViewModel(IPatientService patientService, IEventAggregator eventAggregator)
        {
            _patientService = patientService;
            _eventAggregator = eventAggregator;

            AddPatientCommand = new DelegateCommand(OnAddPatient);
            ViewPatientCommand = new DelegateCommand<Patient>(OnViewPatient);
            EditPatientCommand = new DelegateCommand<Patient>(OnEditPatient);
            SearchCommand = new DelegateCommand(FilterPatients);

            LoadPatients();
        }

        private async void LoadPatients()
        {
            var patients = await _patientService.GetPatientsAsync();
            Patients = new ObservableCollection<Patient>(patients);
            FilteredPatients = new ObservableCollection<Patient>(patients);
        }

        private void FilterPatients()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredPatients = new ObservableCollection<Patient>(Patients);
            }
            else
            {
                FilteredPatients = new ObservableCollection<Patient>(
                    Patients.Where(p => p.FirstName.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase) ||
                                        p.LastName.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase)));
            }
        }

        private void OnAddPatient()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("AddPatientScreen");
        }

        private void OnViewPatient(Patient patient)
        {
            if (patient != null)
            {
                _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("PatientDetailsScreen");
            }
        }

        private void OnEditPatient(Patient patient)
        {
            if (patient != null)
            {
                _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("EditPatientScreen");
            }
        }
    }
}
