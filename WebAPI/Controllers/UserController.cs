using AgendaEscolarApp.Application.Users.Commands;
using AgendaEscolarApp.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AgendaEscolarApp.Domain.Entities;

namespace AgendaEscolarApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CriarUsuario(CreateUsersCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuarios = await _mediator.Send(new GetUsersQuery());
            return Ok(usuarios);
        }
    }
}
