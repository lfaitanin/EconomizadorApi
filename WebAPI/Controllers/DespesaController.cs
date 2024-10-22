using EconomizadorApi.Application.Despesa.Commands;
using EconomizadorApi.Application.Despesa.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DespesaController : ControllerBase
{
    private readonly IMediator _mediator;

    public DespesaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarDespesa([FromBody] AdicionarDespesaCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> ObterDespesas()
    {
        var despesas = await _mediator.Send(new GetDespesasQuery());
        return Ok(despesas);
    }
}
