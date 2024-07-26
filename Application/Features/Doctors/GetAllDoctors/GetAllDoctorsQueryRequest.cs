using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Doctors.GetAllDoctors;

public record GetAllDoctorsQueryRequest() : IRequest<Result<List<Doctor>>>;