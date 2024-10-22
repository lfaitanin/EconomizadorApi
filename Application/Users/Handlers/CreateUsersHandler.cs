using AgendaEscolarApp.Application.Users.Commands;
using MediatR;
using AgendaEscolarApp.Domain.Entities;

namespace AgendaEscolarApp.Application.Users.Handlers
{
    public class CreateUsersHandler : IRequestHandler<CreateUsersCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                TipoUsuario = request.TipoUsuario
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);

            return usuario.Id;
        }
    }
}
