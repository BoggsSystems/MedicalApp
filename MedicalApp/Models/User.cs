using System;

namespace NoahMedical.Core.Models
{

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } // e.g., Admin, Doctor, Technician
    public string Status { get; set; } // e.g., Active, Inactive
    public List<string> Permissions { get; set; }

    public User()
    {
        Permissions = new List<string>();
    }
}

}
