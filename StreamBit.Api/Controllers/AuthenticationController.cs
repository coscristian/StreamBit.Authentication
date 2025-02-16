using StreamBit.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using StreamBit.Application.Services.Authentication;

namespace StreamBit.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
        var response = new AuthenticationResponse(
            loginResult.User.Id,
            loginResult.User.FirstName,
            loginResult.User.LastName,
            loginResult.User.Email,
            loginResult.Token);

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }
}

