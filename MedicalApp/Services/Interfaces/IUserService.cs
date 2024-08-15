using System.Collections.Generic;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <returns>A list of all users.</returns>
        Task<List<User>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">The user data to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddUserAsync(User user);

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="user">The user data to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateUserAsync(User user);

        /// <summary>
        /// Deletes a user from the system by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUserAsync(int id);

        /// <summary>
        /// Authenticates a user by verifying their credentials.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The authenticated user if credentials are valid; otherwise, null.</returns>
        Task<User> AuthenticateAsync(string username, string password);
    }
}
