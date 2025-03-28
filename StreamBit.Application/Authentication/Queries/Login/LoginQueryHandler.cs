using ErrorOr;
using MediatR;
using StreamBit.Application.Authentication.Common;
using StreamBit.Application.Common.Interfaces.Authentication;
using StreamBit.Application.Common.Interfaces.Persistence;
using StreamBit.Domain.Common.Errors;

namespace StreamBit.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}