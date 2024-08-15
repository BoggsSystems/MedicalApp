using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public class ScanService : IScanService
    {
        // This could be a database context or any data source in a real application.
        private readonly List<ScanData> _scans;

        public ScanService()
        {
            // Initialize with some dummy data for illustration purposes
            _scans = new List<ScanData>
            {
                new ScanData { Id = 1, Date = new DateTime(2023, 1, 10), ScanType = "CT", ImagePath = "/images/scan1.png", ReportSummary = "No anomalies detected", TechnicianName = "Alice", ScanStatus = "Completed" },
                new ScanData { Id = 2, Date = new DateTime(2023, 1, 12), ScanType = "MRI", ImagePath = "/images/scan2.png", ReportSummary = "Minor anomaly detected", TechnicianName = "Bob", ScanStatus = "Reviewed" }
            };
        }

        public async Task<List<ScanData>> GetScansByPatientIdAsync(int patientId)
        {
            // Simulate retrieving scans for a specific patient
            var scans = _scans.Where(s => s.Id == patientId).ToList();
            return await Task.FromResult(scans);
        }

        public async Task<ScanData> GetScanByIdAsync(int id)
        {
            var scan = _scans.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(scan);
        }

        public async Task AddScanAsync(ScanData scan)
        {
            // Simulate adding a new scan
            scan.Id = _scans.Max(s => s.Id) + 1;
            _scans.Add(scan);
            await Task.CompletedTask;
        }

        public async Task UpdateScanAsync(ScanData scan)
        {
            var existingScan = _scans.FirstOrDefault(s => s.Id == scan.Id);
            if (existingScan != null)
            {
                existingScan.Date = scan.Date;
                existingScan.ScanType = scan.ScanType;
                existingScan.ImagePath = scan.ImagePath;
                existingScan.ReportSummary = scan.ReportSummary;
                existingScan.TechnicianName = scan.TechnicianName;
                existingScan.ScanStatus = scan.ScanStatus;
            }
            await Task.CompletedTask;
        }
    }
}
