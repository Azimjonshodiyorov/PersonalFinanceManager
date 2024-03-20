using PersonalFinance.Application.ViewModel.Request.User;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.Interfaces;

public interface IAuthenticationService
{
    ValueTask<Token> Login(LoginRequest request);
    ValueTask<UserResponse> Register(CreateUserRequest userRequest);
}