using ErrorOr;
using MediatR;
using StreamBit.Application.Authentication.Common;

namespace StreamBit.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;