using MediatR;
using TS.Result;

namespace Application.Features.Doctors.UpdateDoctor;

public class UpdateDoctorCommandRequest : IRequest<Result<string>>
{
    public Guid DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentValue { get; set; }
}