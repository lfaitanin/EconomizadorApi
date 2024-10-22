using MediatR;

namespace EconomizadorApi.Application.Categoria.Commands
{
    public class AdicionarCategoriaCommand : IRequest<int>
    {
        public string Nome { get; set; }
    }
}
