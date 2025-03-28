using StreamBit.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StreamBit.Application.Authentication.Commands.Register;
using StreamBit.Application.Authentication.Queries.Login;
using StreamBit.Application.Authentication.Common;

namespace StreamBit.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginQuery(request.Email, request.Password);
        var loginResult = await _mediator.Send(command);

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
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var registerResult = await _mediator.Send(command);

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

