using System;

namespace NoahMedical.Core.Models
{
    public class ScanData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ScanType { get; set; }
        public string ImagePath { get; set; }
        public string ReportSummary { get; set; }

        // Additional properties can be added as needed
        public string TechnicianName { get; set; }
        public string ScanStatus { get; set; }

        public ScanData()
        {
            // Initialize any default values if necessary
        }
    }
}
