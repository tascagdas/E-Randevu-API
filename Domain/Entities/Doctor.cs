using Domain.Enums;

namespace Domain.Entities;

public class Doctor
{
    public Guid DoctorId { get; set; } = Guid.NewGuid();
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => string.Join(" ", FirstName, LastName);
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Doktor;
}