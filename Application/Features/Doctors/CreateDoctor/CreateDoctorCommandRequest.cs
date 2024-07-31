using MediatR;
using TS.Result;

namespace Application.Features.Doctors.CreateDoctor;

public record CreateDoctorCommandRequest(
    string FirstName,
    string LastName,
    int DepartmentValue) :IRequest<Result<string>>;