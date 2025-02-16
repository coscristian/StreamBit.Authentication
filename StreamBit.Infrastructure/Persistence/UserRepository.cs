using StreamBit.Application.Common.Interfaces.Persistence;
using StreamBit.Domain.Entities;

namespace StreamBit.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public Task<User?> GetUserByEmailAsync(string email) => Task.FromResult(_users.SingleOrDefault(u => u.Email == email));    
    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

}
