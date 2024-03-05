using MediatR;
using UserManagement.Application.Commands;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Handlers
{
    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeactivateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeactivateUser(request.Id);
        }
    }
}
