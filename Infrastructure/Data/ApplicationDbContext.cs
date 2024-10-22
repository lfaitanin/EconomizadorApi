using AgendaEscolarApp.Domain.Entities;
using EconomizadorApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Despesas> Despesas { get; set; }
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
}

