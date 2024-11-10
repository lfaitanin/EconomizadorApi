using EconomizadorApi.Application.Receitas.Queries;
using EconomizadorApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Receitas.Handlers
{
    public class GetReceitasHandler : IRequestHandler<GetReceitasQuery, List<Receita>>
    {
        private readonly ApplicationDbContext _context;

        public GetReceitasHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Receita>> Handle(GetReceitasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Receitas
                        .Where(r => r.UsuarioId == request.UsuarioId)
                        .ToListAsync(cancellationToken);
        }
    }

}
