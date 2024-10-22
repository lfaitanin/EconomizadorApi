using EconomizadorApi.Application.Financeiro.Queries;
using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class DetalharDespesasPorCategoriaHandler : IRequestHandler<DetalharDespesasPorCategoriaQuery, List<DespesaDetalhadaDTO>>
    {
        private readonly ApplicationDbContext _context;

        public DetalharDespesasPorCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DespesaDetalhadaDTO>> Handle(DetalharDespesasPorCategoriaQuery request, CancellationToken cancellationToken)
        {
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            var despesas = await _context.Despesas
                .Where(d => d.Data >= dataInicioUtc && d.Data <= dataFimUtc)
                .Select(d => new DespesaDetalhadaDTO
                {
                    Categoria = d.Categoria.Nome,
                    Descricao = d.Descricao,
                    Valor = d.Valor
                })
                .ToListAsync(cancellationToken);

            return despesas;
        }
    }
}
