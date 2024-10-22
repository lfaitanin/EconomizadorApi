using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class DetalharDespesasPorCategoriaQuery : IRequest<List<DespesaDetalhadaDTO>>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

}
