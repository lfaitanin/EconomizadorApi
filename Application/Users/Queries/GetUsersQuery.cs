using MediatR;
using AgendaEscolarApp.Domain.Entities;

namespace AgendaEscolarApp.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<List<Usuario>>
    {
    }
}
