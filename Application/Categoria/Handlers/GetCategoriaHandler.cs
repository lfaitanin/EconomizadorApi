using EconomizadorApi.Application.Categoria.Queries;
using EconomizadorApi.Application.Despesa.Queries;
using EconomizadorApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Categoria.Handlers
{
    public class GetCategoriaHandler : IRequestHandler<GetCategoriaQuery, List<Categorias>>
    {
        private readonly ApplicationDbContext _context;

        public GetCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorias>> Handle(GetCategoriaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categorias.ToListAsync(cancellationToken);
        }
    }
}
