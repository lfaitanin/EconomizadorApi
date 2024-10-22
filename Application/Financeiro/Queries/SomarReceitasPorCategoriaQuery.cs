using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class SomarReceitasPorCategoriaQuery : IRequest<List<ReceitaCategoriaDTO>>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

}
