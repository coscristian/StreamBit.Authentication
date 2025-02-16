using StreamBit.Domain.Entities;

namespace StreamBit.Application.Services.Authentication;
public record AuthenticationResult(
    User User,
    string Token
);
