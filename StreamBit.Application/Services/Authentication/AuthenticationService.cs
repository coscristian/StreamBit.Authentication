using ErrorOr;
using StreamBit.Application.Common.Interfaces.Authentication;
using StreamBit.Application.Common.Interfaces.Persistence;
using StreamBit.Domain.Entities;
using StreamBit.Domain.Common.Errors;

namespace StreamBit.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public async Task<ErrorOr<AuthenticationResult>> Register(string firstName, string lastName, string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is not null)
        {
            return Errors.User.DuplicateEmail;            
        }

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await _userRepository.AddAsync(newUser);

        var token = _jwtTokenGenerator.GenerateToken(newUser);

        return new AuthenticationResult(
            newUser,
            token);
    }
}

