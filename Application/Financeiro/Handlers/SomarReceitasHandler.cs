using EconomizadorApi.Application.Financeiro.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class SomarReceitasHandler : IRequestHandler<SomarReceitasQuery, decimal>
    {
        private readonly ApplicationDbContext _context;

        public SomarReceitasHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Handle(SomarReceitasQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Receitas.AsQueryable();
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            query = query.Where(r => r.Data >= dataInicioUtc && r.Data <= dataFimUtc);

            if (request.CategoriaId.HasValue)
            {
                query = query.Where(r => r.CategoriaId == request.CategoriaId.Value);
            }

            var total = await query.SumAsync(r => r.Valor, cancellationToken);
            return total;
        }
    }


}
