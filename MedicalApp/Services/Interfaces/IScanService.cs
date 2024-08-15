using System.Collections.Generic;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public interface IScanService
    {
        /// <summary>
        /// Retrieves all scans associated with a specific patient by their ID.
        /// </summary>
        /// <param name="patientId">The ID of the patient whose scans are to be retrieved.</param>
        /// <returns>A list of scans associated with the patient.</returns>
        Task<List<ScanData>> GetScansByPatientIdAsync(int patientId);

        /// <summary>
        /// Retrieves a specific scan by its ID.
        /// </summary>
        /// <param name="id">The ID of the scan to be retrieved.</param>
        /// <returns>The scan with the specified ID.</returns>
        Task<ScanData> GetScanByIdAsync(int id);

        /// <summary>
        /// Adds a new scan to the system.
        /// </summary>
        /// <param name="scan">The scan data to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddScanAsync(ScanData scan);

        /// <summary>
        /// Updates an existing scan with new information.
        /// </summary>
        /// <param name="scan">The scan data to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateScanAsync(ScanData scan);
    }
}
