using MediatR;

namespace EconomizadorApi.Application.Despesa.Commands
{
    public class AdicionarDespesaCommand : IRequest<int>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public string UsuarioId { get; set; }
    }
}
