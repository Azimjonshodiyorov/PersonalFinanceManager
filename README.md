# Personal Finance Manager project

This is a simple API example for managing personal finances built in .NET 8, utilizing Clean Architecture principles.

## Overview

The Personal Finances API provides endpoints for managing user accounts,  categories related to personal finance management. It follows the principles of Clean Architecture, ensuring a separation of concerns and maintainability of the codebase.

## Features

- **User Management**: Create, retrieve, update, and delete user accounts.
- **Category Management**: Create, retrieve, update, and delete  categories.

## Technologies Used

- **.NET 8**: The core framework used for building the API.
- **Entity Framework Core**: For interacting with the database.
- **Swagger UI**: Integrated documentation and testing interface.
- **Clean Architecture**: Ensures separation of concerns and maintainability.
- **Serilog**
- **Authentication JwtBearer**

## Installation

1. Clone the repository.
2. Ensure you have .NET 8 SDK installed.
3. Configure your database connection in `appsettings.Development.json`.
4. Ef core migrations
5. Run `dotnet build` to build the project.
6. Run `dotnet run` to start the API.

## Usage

- The API endpoints are documented using Swagger UI. Access the documentation by navigating to `/swagger` after starting the API.
