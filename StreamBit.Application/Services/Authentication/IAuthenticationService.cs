﻿namespace StreamBit.Application.Services.Authentication;
public interface IAuthenticationService
{
    Task<AuthenticationResult> Login(string email, string password);
    Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
