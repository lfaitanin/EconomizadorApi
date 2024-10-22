using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class SomarDespesasPorCategoriaQuery : IRequest<List<DespesaCategoriaDTO>>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

}
