using EconomizadorApi.Application.Categoria.Commands;
using EconomizadorApi.Application.Despesa.Commands;
using EconomizadorApi.Domain.Entities;
using MediatR;

namespace EconomizadorApi.Application.Categoria.Handlers
{
    public class AdicionarCategoriaHandler : IRequestHandler<AdicionarCategoriaCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AdicionarCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AdicionarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categorias
            {
                Nome = request.Nome,
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync(cancellationToken);

            return categoria.Id;
        }
    }
}
