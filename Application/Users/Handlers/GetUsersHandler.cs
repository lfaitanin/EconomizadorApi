using AgendaEscolarApp.Application.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AgendaEscolarApp.Domain.Entities;

namespace AgendaEscolarApp.Application.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<Usuario>>
    {
        private readonly ApplicationDbContext _context;

        public GetUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.ToListAsync(cancellationToken);
        }
    }
}
