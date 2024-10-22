using EconomizadorApi.Application.Receitas.Commands;
using EconomizadorApi.Domain.Entities;
using MediatR;

namespace EconomizadorApi.Application.Receitas.Handlers
{
    public class AdicionarReceitaHandler : IRequestHandler<AdicionarReceitaCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AdicionarReceitaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AdicionarReceitaCommand request, CancellationToken cancellationToken)
        {
            var receita = new Receita
            {
                Descricao = request.Descricao,
                Valor = request.Valor,
                Data = request.Data,
                CategoriaId = request.CategoriaId
            };

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync(cancellationToken);

            return receita.Id;
        }
    }

}
