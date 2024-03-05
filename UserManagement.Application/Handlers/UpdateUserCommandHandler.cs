using MediatR;
using UserManagement.Application.Commands;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUser(request.User);
        }
    }
}
