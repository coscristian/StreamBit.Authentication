using StreamBit.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using StreamBit.Application.Services.Authentication;

namespace StreamBit.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var loginResult = await _authenticationService.Login(request.Email, request.Password);   
        return loginResult.Match(
            result => Ok(MapLoginResult(loginResult.Value)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapLoginResult(AuthenticationResult loginResult)
    {
        return new AuthenticationResponse(
            loginResult.User.Id,
            loginResult.User.FirstName,
            loginResult.User.LastName,
            loginResult.User.Email,
            loginResult.Token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerResult = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        return registerResult.Match(
            result => Ok(MapRegisterResult(registerResult.Value)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapRegisterResult(AuthenticationResult registerResult)
    {
        return new AuthenticationResponse(
            registerResult.User.Id,
            registerResult.User.FirstName,
            registerResult.User.LastName,
            registerResult.User.Email,
            registerResult.Token);
    }
}

