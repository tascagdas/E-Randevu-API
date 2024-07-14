namespace Domain.Entities;

public class Patient
{
    public Guid PatientId { get; set; } = Guid.NewGuid();
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? IdentityNumber { get; set; }
    public string? City { get; set; }
    public string? Town { get; set; }
    public string? FullAddress { get; set; }
}