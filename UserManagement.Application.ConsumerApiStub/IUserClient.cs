using UserManagement.Domain.Entities;

namespace UserManagement.Application.ConsumerApiStub
{
    public interface IUserClient
    {
        Task CreateUserAsync(User user);
        Task DeactivateUserAsync(Guid id);
        Task UpdateUserAsync(User user);
    }
}