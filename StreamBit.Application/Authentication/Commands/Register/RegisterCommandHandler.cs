using ErrorOr;
using MediatR;
using StreamBit.Application.Authentication.Common;
using StreamBit.Application.Common.Interfaces.Authentication;
using StreamBit.Application.Common.Interfaces.Persistence;
using StreamBit.Domain.Common.Errors;
using StreamBit.Domain.Entities;

namespace StreamBit.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is not null)
        {
            return Errors.User.DuplicateEmail;            
        }

        var newUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        await _userRepository.AddAsync(newUser);

        var token = _jwtTokenGenerator.GenerateToken(newUser);

        return new AuthenticationResult(
            newUser,
            token);
    }
}