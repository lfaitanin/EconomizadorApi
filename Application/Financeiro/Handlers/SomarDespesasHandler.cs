using EconomizadorApi.Application.Financeiro.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class SomarDespesasHandler : IRequestHandler<SomarDespesasQuery, decimal>
    {
        private readonly ApplicationDbContext _context;

        public SomarDespesasHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Handle(SomarDespesasQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Despesas.AsQueryable();

            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            query = query.Where(r => r.Data >= dataInicioUtc && r.Data <= dataFimUtc);

            if (request.CategoriaId.HasValue)
            {
                query = query.Where(d => d.CategoriaId == request.CategoriaId.Value);
            }

            var total = await query.SumAsync(d => d.Valor, cancellationToken);
            return total;
        }
    }

}
