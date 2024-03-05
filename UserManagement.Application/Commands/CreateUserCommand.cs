using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public required User User { get; set; }
    }
}
