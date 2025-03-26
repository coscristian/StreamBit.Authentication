# StreamBit.Authentication

StreamBit is a personal side project currently under development. The goal of this web application is to provide a platform for streaming sports, movies, and other types of content. This repository, `StreamBit.Authentication`, is the authentication module of the application, built using .NET 9.0. It handles user registration, login, and authentication using JSON Web Tokens (JWT).

## Project Structure

The project is organized into the following layers:

- **StreamBit.Api**: Contains the API controllers and configuration for handling HTTP requests.
- **StreamBit.Application**: Implements the business logic and application services.
- **StreamBit.Contracts**: Defines the data contracts used for communication between layers.
- **StreamBit.Domain**: Contains the core domain models and error definitions.
- **StreamBit.Infrastructure**: Provides infrastructure services such as JWT token generation and data persistence.

## Features

- **User Authentication**: Secure login and registration using JWT.
- **Error Handling**: Centralized error management with detailed error codes.
- **Scalable Architecture**: Modular design for easy maintenance and scalability.
- **In-Memory User Repository**: A simple in-memory database for development purposes.

## Prerequisites

- .NET 9.0 SDK
- Visual Studio or Visual Studio Code
- SQL Server (optional, for future database integration)

## Initial Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/StreamBit.Authentication.git
   cd StreamBit.Authentication
