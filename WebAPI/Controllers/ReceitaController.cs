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
    public async Task<IActionResult> ObterReceitas()
    {
        var receitas = await _mediator.Send(new GetReceitasQuery());
        return Ok(receitas);
    }
}
