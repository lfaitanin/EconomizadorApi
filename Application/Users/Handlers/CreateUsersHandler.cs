using AgendaEscolarApp.Application.Users.Commands;
using MediatR;
using AgendaEscolarApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AgendaEscolarApp.Application.Users.Handlers
{
    public class CreateUsersHandler : IRequestHandler<CreateUsersCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public CreateUsersHandler(ApplicationDbContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;

        }

        public async Task<Guid> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == request.Email, cancellationToken))
            {
                throw new System.Exception("O email já está em uso.");
            }

            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email
            };

            usuario.Senha = _passwordHasher.HashPassword(usuario, request.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);

            return usuario.Id; 
        }
    }
}
