using StreamBit.Domain.Entities;

namespace StreamBit.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);