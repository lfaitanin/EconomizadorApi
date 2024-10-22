using EconomizadorApi.Application.Categoria.Commands;
using EconomizadorApi.Application.Categoria.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarCategoria([FromBody] AdicionarCategoriaCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> ObterCategorias()
    {
        var receitas = await _mediator.Send(new GetCategoriaQuery());
        return Ok(receitas);
    }
}
