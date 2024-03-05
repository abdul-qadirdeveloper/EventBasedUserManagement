using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public required User User { get; set; }
    }
}
