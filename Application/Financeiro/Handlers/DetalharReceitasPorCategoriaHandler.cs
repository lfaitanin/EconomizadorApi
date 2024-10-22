using EconomizadorApi.Application.Financeiro.Queries;
using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class DetalharReceitasPorCategoriaHandler : IRequestHandler<DetalharReceitasPorCategoriaQuery, List<ReceitaDetalhadaDTO>>
    {
        private readonly ApplicationDbContext _context;

        public DetalharReceitasPorCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReceitaDetalhadaDTO>> Handle(DetalharReceitasPorCategoriaQuery request, CancellationToken cancellationToken)
        {
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            var receitas = await _context.Receitas
                .Where(r => r.Data >= dataInicioUtc && r.Data <= dataFimUtc)
                .Select(r => new ReceitaDetalhadaDTO
                {
                    Categoria = r.Categoria.Nome,
                    Descricao = r.Descricao,
                    Valor = r.Valor
                })
                .ToListAsync(cancellationToken);

            return receitas;
        }
    }
}
