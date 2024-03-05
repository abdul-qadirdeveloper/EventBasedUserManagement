using MediatR;
using UserManagement.Application.Commands;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateUser(request.User);
        }
    }
}
