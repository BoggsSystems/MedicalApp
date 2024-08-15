using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public class PatientService : IPatientService
    {
        // This could be a database context or any data source in a real application.
        private readonly List<Patient> _patients;

        public PatientService()
        {
            // Initialize with some dummy data for illustration purposes
            _patients = new List<Patient>
            {
                new Patient { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 5, 15), Gender = "Male", MedicalHistory = "Diabetes" },
                new Patient { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1992, 7, 20), Gender = "Female", MedicalHistory = "Asthma" }
            };
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            // Simulate an asynchronous operation
            return await Task.FromResult(_patients);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(patient);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            // Simulate adding a new patient
            patient.Id = _patients.Max(p => p.Id) + 1;
            _patients.Add(patient);
            await Task.CompletedTask;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.Gender = patient.Gender;
                existingPatient.MedicalHistory = patient.MedicalHistory;
            }
            await Task.CompletedTask;
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
            await Task.CompletedTask;
        }
    }
}
