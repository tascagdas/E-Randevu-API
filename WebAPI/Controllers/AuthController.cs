using Application.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController (IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
