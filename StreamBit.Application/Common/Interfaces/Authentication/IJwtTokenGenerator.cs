using StreamBit.Domain.Entities;

namespace StreamBit.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
