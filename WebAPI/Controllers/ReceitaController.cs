using AgendaEscolarApp.Domain.Entities;
using EconomizadorApi.Application.Despesa.Queries;
using EconomizadorApi.Application.Receitas.Commands;
using EconomizadorApi.Application.Receitas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReceitaController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceitaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarReceita([FromBody] AdicionarReceitaCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> ObterReceitas([FromQuery] string usuarioId)
    {
        var query = new GetDespesasQuery { UsuarioId = usuarioId };
        var receitas = await _mediator.Send(query);
        return Ok(receitas);
    }
}
