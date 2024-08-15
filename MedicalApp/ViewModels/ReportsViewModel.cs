// ReportsViewModel.cs
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoahMedical.Core.Models;
using NoahMedical.Core.Services;

namespace NoahMedical.ViewModels
{
    public class ReportsViewModel : BindableBase
    {
        private readonly IReportService _reportService;
        private string _selectedReportType;
        private DateTime _startDate;
        private DateTime _endDate;
        private ObservableCollection<ReportData> _reportData;

        public ObservableCollection<string> ReportTypes { get; }
        public string SelectedReportType
        {
            get => _selectedReportType;
            set => SetProperty(ref _selectedReportType, value);
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public ObservableCollection<ReportData> ReportData
        {
            get => _reportData;
            set => SetProperty(ref _reportData, value);
        }

        public ICommand GenerateReportCommand { get; }
        public ICommand ExportToPdfCommand { get; }
        public ICommand ExportToExcelCommand { get; }

        public ReportsViewModel(IReportService reportService)
        {
            _reportService = reportService;
            ReportTypes = new ObservableCollection<string>
            {
                "Daily Summary",
                "Performance Metrics",
                "Activity Logs"
            };
            StartDate = DateTime.Today.AddDays(-7); // Default to last week
            EndDate = DateTime.Today;

            GenerateReportCommand = new DelegateCommand(OnGenerateReport);
            ExportToPdfCommand = new DelegateCommand(OnExportToPdf);
            ExportToExcelCommand = new DelegateCommand(OnExportToExcel);
        }

        private void OnGenerateReport()
        {
            if (string.IsNullOrEmpty(SelectedReportType))
                return;

            // Fetch and update report data based on selected type and date range
            var data = _reportService.GenerateReport(SelectedReportType, StartDate, EndDate);
            ReportData = new ObservableCollection<ReportData>(data);
        }

        private void OnExportToPdf()
        {
            if (ReportData == null || ReportData.Count == 0)
                return;

            _reportService.ExportToPdf(ReportData, SelectedReportType);
        }

        private void OnExportToExcel()
        {
            if (ReportData == null || ReportData.Count == 0)
                return;

            _reportService.ExportToExcel(ReportData, SelectedReportType);
        }
    }
}
