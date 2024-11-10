using EconomizadorApi.Application.Despesa.Queries;
using EconomizadorApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Despesa.Handlers
{
    public class GetDespesasHandler : IRequestHandler<GetDespesasQuery, List<Despesas>>
    {
        private readonly ApplicationDbContext _context;

        public GetDespesasHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Despesas>> Handle(GetDespesasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Despesas.Include(d => d.Categoria).Where(d => d.UsuarioId == request.UsuarioId).ToListAsync(cancellationToken);
        }
    }

}
