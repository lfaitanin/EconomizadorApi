using MediatR;

namespace EconomizadorApi.Application.Financeiro.Queries
{
    public class SomarReceitasQuery : IRequest<decimal>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? CategoriaId { get; set; } 
    }
}
