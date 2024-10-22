using AgendaEscolarApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    //public DbSet<Aluno> Alunos { get; set; }
    //public DbSet<Evento> Eventos { get; set; }
    //// Outras tabelas...
}

