namespace Domain.Entities;

public class Appointment
{
    public Guid AppointmentId { get; set; } = Guid.NewGuid();
    public Guid DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }
    public DateTime StarTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsCompleted { get; set; }
    
}