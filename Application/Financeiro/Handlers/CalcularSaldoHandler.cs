using EconomizadorApi.Application.Financeiro.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class CalcularSaldoHandler : IRequestHandler<CalcularSaldoQuery, decimal>
    {
        private readonly ApplicationDbContext _context;

        public CalcularSaldoHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Handle(CalcularSaldoQuery request, CancellationToken cancellationToken)
        {
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            var receitasQuery = _context.Receitas.AsQueryable()
                .Where(r => r.Data >= dataInicioUtc && r.Data <= dataFimUtc);
            if (request.CategoriaId.HasValue)
            {
                receitasQuery = receitasQuery.Where(r => r.CategoriaId == request.CategoriaId.Value);
            }
            var totalReceitas = await receitasQuery.SumAsync(r => r.Valor, cancellationToken);

            // Somar despesas
            var despesasQuery = _context.Despesas.AsQueryable()
                .Where(d => d.Data >= dataInicioUtc && d.Data <= dataFimUtc);
            if (request.CategoriaId.HasValue)
            {
                despesasQuery = despesasQuery.Where(d => d.CategoriaId == request.CategoriaId.Value);
            }
            var totalDespesas = await despesasQuery.SumAsync(d => d.Valor, cancellationToken);

            // Calcular saldo
            var saldo = totalReceitas - totalDespesas;
            return saldo;
        }
    }

}
