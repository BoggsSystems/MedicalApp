using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoahMedical.Core.Models;

namespace NoahMedical.Core.Services
{
    public class UserService : IUserService
    {
        // This could be a database context or any data source in a real application.
        private readonly List<User> _users;

        public UserService()
        {
            // Initialize with some dummy data for illustration purposes
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = HashPassword("admin123"),
                    Email = "admin@noahmedical.com",
                    Role = "Admin",
                    Status = "Active",
                    Permissions = new List<string> { "ManageUsers", "ViewReports" }
                },
                new User
                {
                    Id = 2,
                    Username = "doctor",
                    PasswordHash = HashPassword("doctor123"),
                    Email = "doctor@noahmedical.com",
                    Role = "Doctor",
                    Status = "Active",
                    Permissions = new List<string> { "ViewPatients", "UpdatePatients" }
                }
            };
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // Simulate an asynchronous operation
            return await Task.FromResult(_users);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(user);
        }

        public async Task AddUserAsync(User user)
        {
            // Simulate adding a new user
            user.Id = _users.Max(u => u.Id) + 1;
            user.PasswordHash = HashPassword(user.PasswordHash); // Hash the password
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.Status = user.Status;
                existingUser.Permissions = user.Permissions;
                // Update password if provided
                if (!string.IsNullOrEmpty(user.PasswordHash))
                {
                    existingUser.PasswordHash = HashPassword(user.PasswordHash);
                }
            }
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            await Task.CompletedTask;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && u.PasswordHash == HashPassword(password)
            );
            return await Task.FromResult(user);
        }

        private string HashPassword(string password)
        {
            // Implement a simple hashing mechanism for demonstration purposes
            // In production, use a secure hashing algorithm such as bcrypt or PBKDF2
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
