using Application.Features.Doctors.CreateDoctor;
using Application.Features.Doctors.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Abstractions;

namespace WebAPI.Controllers;

public class DoctorsController : ApiController
{
    public DoctorsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllDoctors(GetAllDoctorsQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDoctor(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}