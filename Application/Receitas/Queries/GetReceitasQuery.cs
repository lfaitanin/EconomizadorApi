using EconomizadorApi.Domain.Entities;
using MediatR;

namespace EconomizadorApi.Application.Receitas.Queries
{
    public class GetReceitasQuery : IRequest<List<Receita>>
    {
    }
}
