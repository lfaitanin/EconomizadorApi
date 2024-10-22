using EconomizadorApi.Application.Financeiro.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EconomizadorApi.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinanceiroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("receitas")]
        public async Task<IActionResult> SomarReceitas(DateTime dataInicio, DateTime dataFim, int? categoriaId = null)
        {
            var query = new SomarReceitasQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                CategoriaId = categoriaId
            };
            var total = await _mediator.Send(query);
            return Ok(total);
        }

        [HttpGet("despesas")]
        public async Task<IActionResult> SomarDespesas(DateTime dataInicio, DateTime dataFim, int? categoriaId = null)
        {
            var query = new SomarDespesasQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                CategoriaId = categoriaId
            };
            var total = await _mediator.Send(query);
            return Ok(total);
        }

        [HttpGet("saldo")]
        public async Task<IActionResult> CalcularSaldo(DateTime dataInicio, DateTime dataFim, int? categoriaId = null)
        {
            var query = new CalcularSaldoQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                CategoriaId = categoriaId
            };
            var saldo = await _mediator.Send(query);
            return Ok(saldo);
        }
        [HttpGet("despesas-por-categoria")]
        public async Task<IActionResult> SomarDespesasPorCategoria(DateTime dataInicio, DateTime dataFim)
        {
            var query = new SomarDespesasPorCategoriaQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim
            };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("detalhar-despesas")]
        public async Task<IActionResult> DetalharDespesasPorCategoria(DateTime dataInicio, DateTime dataFim)
        {
            var query = new DetalharDespesasPorCategoriaQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim
            };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("receitas-por-categoria")]
        public async Task<IActionResult> SomarReceitasPorCategoria(DateTime dataInicio, DateTime dataFim)
        {
            var query = new SomarReceitasPorCategoriaQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim
            };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("detalhar-receitas")]
        public async Task<IActionResult> DetalharReceitasPorCategoria(DateTime dataInicio, DateTime dataFim)
        {
            var query = new DetalharReceitasPorCategoriaQuery
            {
                DataInicio = dataInicio,
                DataFim = dataFim
            };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }
    }

}
