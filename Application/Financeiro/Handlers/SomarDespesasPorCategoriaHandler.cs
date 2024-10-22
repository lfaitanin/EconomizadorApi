using EconomizadorApi.Application.Financeiro.Queries;
using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class SomarDespesasPorCategoriaHandler : IRequestHandler<SomarDespesasPorCategoriaQuery, List<DespesaCategoriaDTO>>
    {
        private readonly ApplicationDbContext _context;

        public SomarDespesasPorCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DespesaCategoriaDTO>> Handle(SomarDespesasPorCategoriaQuery request, CancellationToken cancellationToken)
        {
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            var despesas = await _context.Despesas
                .Where(d => d.Data >= dataInicioUtc && d.Data <= dataFimUtc)
                .GroupBy(d => d.Categoria.Nome)
                .Select(group => new DespesaCategoriaDTO
                {
                    Categoria = group.Key,
                    ValorTotal = group.Sum(d => d.Valor)
                })
                .ToListAsync(cancellationToken);

            return despesas;
        }
    }
}
