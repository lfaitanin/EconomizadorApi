using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class DetalharReceitasPorCategoriaQuery : IRequest<List<ReceitaDetalhadaDTO>>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
