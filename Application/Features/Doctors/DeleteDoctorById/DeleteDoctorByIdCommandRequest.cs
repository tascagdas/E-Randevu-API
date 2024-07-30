using MediatR;
using TS.Result;

namespace Application.Features.Doctors.DeleteDoctorById;

public record DeleteDoctorByIdCommandRequest(
    Guid Id
    ):IRequest<Result<string>>;