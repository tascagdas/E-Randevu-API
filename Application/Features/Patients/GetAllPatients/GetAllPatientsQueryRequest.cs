using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.GetAllPatients;

public record GetAllPatientsQueryRequest(): IRequest<Result<List<Patient>>>;