using AgendaEscolarApp.Domain.Entities;

namespace EconomizadorApi.Domain.Entities
{
    public class Despesas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public Categorias Categoria { get; set; }
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}
