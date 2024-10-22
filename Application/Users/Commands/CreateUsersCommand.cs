using AgendaEscolarApp.Domain.Entities.Enum;
using MediatR;


namespace AgendaEscolarApp.Application.Users.Commands
{
    public class CreateUsersCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
