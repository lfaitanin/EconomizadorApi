using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class SomarDespesasQuery : IRequest<decimal>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? CategoriaId { get; set; }  
    }

}
