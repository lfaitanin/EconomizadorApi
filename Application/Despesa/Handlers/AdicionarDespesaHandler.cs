using EconomizadorApi.Application.Despesa.Commands;
using MediatR;
using EconomizadorApi.Domain.Entities;

namespace EconomizadorApi.Application.Despesa.Handlers
{
    public class AdicionarDespesaHandler : IRequestHandler<AdicionarDespesaCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AdicionarDespesaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AdicionarDespesaCommand request, CancellationToken cancellationToken)
        {
            var despesa = new Despesas
            {
                Descricao = request.Descricao,
                Valor = request.Valor,
                Data = request.Data,
                CategoriaId = request.CategoriaId
            };

            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync(cancellationToken);

            return despesa.Id;
        }
    }
}
