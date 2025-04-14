using ErrorOr;
using MediatR;
using StreamBit.Application.Authentication.Common;

namespace StreamBit.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;