using System;
using System.Collections.Generic;

namespace NoahMedical.Core.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MedicalHistory { get; set; }
        public List<ScanData> ScanHistory { get; set; }

        // Convenience property to get the full name of the patient
        public string FullName => $"{FirstName} {LastName}";

        public Patient()
        {
            ScanHistory = new List<ScanData>();
        }
    }
}
