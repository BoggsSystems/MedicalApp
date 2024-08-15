// ScanReportViewModel.cs
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System.Windows.Input;
using NoahMedical.Core.Models;
using NoahMedical.Events;

namespace NoahMedical.ViewModels
{
    public class ScanReportViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private ScanData _selectedScan;

        public ScanData SelectedScan
        {
            get => _selectedScan;
            set => SetProperty(ref _selectedScan, value);
        }

        public ICommand BackToPatientDetailsCommand { get; }
        public ICommand ExportReportCommand { get; }

        public ScanReportViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            BackToPatientDetailsCommand = new DelegateCommand(OnBackToPatientDetails);
            ExportReportCommand = new DelegateCommand(OnExportReport);

            // Subscribe to events to receive the selected scan data
            _eventAggregator.GetEvent<SelectedScanChangedEvent>().Subscribe(OnSelectedScanChanged);
        }

        private void OnSelectedScanChanged(ScanData scan)
        {
            SelectedScan = scan;
        }

        private void OnBackToPatientDetails()
        {
            _eventAggregator.GetEvent<NavigateToScreenEvent>().Publish("PatientDetailsScreen");
        }

        private void OnExportReport()
        {
            // Logic to export the scan report
        }
    }
}
