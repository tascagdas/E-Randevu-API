using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    [MaxLength(50)]
    public string? FirstName { get; set; } = string.Empty;
    [MaxLength(40)]
    public string? LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
}