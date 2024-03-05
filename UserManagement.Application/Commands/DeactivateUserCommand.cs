using MediatR;

namespace UserManagement.Application.Commands
{
    public class DeactivateUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
