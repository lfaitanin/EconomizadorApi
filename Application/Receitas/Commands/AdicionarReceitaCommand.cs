using MediatR;

namespace EconomizadorApi.Application.Receitas.Commands
{
    public class AdicionarReceitaCommand : IRequest<int>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
    }
}
