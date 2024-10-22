using EconomizadorApi.Domain.Entities;
using MediatR;

namespace EconomizadorApi.Application.Categoria.Queries
{
    public class GetCategoriaQuery : IRequest<List<Categorias>>
    {
    }
}
