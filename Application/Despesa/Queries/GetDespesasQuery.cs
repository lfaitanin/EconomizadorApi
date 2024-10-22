using EconomizadorApi.Domain.Entities;
using MediatR;

namespace EconomizadorApi.Application.Despesa.Queries
{
    public class GetDespesasQuery : IRequest<List<Despesas>>
    {
    }
}
