using Application.Features.Appointments.CreateAppointment;
using Application.Features.Appointments.GetAppointmentsByDoctorId;
using Application.Features.Appointments.GetDoctorsByDepartmentQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Abstractions;

namespace WebAPI.Controllers;

public class AppointmentsController : ApiController
{
    public AppointmentsController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> GetDoctorsByDepartment(GetDoctorsByDepartmentQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAppointmentsByDoctorId(GetAppointmentsByDoctorIdQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateByIdentityNumber(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}