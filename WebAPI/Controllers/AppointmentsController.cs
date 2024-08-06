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
}