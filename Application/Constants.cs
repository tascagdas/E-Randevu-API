using Domain.Entities;

namespace Application;

public static class Constants
{
    public static List<AppRole> GetRoles()
    {
        List<string> roles = new()
        {
            "Admin",
            "Doctor",
            "Employee",
            "Patient"
        };
        return roles.Select(r => new AppRole() { Name = r }).ToList();
    }
}

