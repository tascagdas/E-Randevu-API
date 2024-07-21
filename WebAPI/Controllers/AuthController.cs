using Application.Features.Auth.Login;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using WebAPI.Abstractions;

namespace WebAPI.Controllers
{
    public class AuthController :ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
