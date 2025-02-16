using StreamBit.Domain.Entities;

namespace StreamBit.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddAsync(User user);
}

