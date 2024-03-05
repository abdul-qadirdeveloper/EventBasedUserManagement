using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeactivateUser(Guid userId);
    }
}
