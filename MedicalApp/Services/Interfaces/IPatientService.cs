using System.Collections.Generic;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public interface IPatientService
    {
        /// <summary>
        /// Retrieves all patients from the system.
        /// </summary>
        /// <returns>A list of all patients.</returns>
        Task<List<Patient>> GetAllPatientsAsync();

        /// <summary>
        /// Retrieves a specific patient by their ID.
        /// </summary>
        /// <param name="id">The ID of the patient to retrieve.</param>
        /// <returns>The patient with the specified ID.</returns>
        Task<Patient> GetPatientByIdAsync(int id);

        /// <summary>
        /// Adds a new patient to the system.
        /// </summary>
        /// <param name="patient">The patient data to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddPatientAsync(Patient patient);

        /// <summary>
        /// Updates an existing patient's information.
        /// </summary>
        /// <param name="patient">The patient data to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdatePatientAsync(Patient patient);

        /// <summary>
        /// Deletes a patient from the system by their ID.
        /// </summary>
        /// <param name="id">The ID of the patient to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeletePatientAsync(int id);
    }
}
