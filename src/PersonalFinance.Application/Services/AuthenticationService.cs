using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.User;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthenticationService(IUserRepository userRepository , ITokenService tokenService , IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    public async ValueTask<Token> Login(LoginRequest request)
    {
        var user = await this._userRepository.GetByEmailAsync(request.Email);
        if (user is null)
            throw new BusinessException("Invalid email");
        
        var token = this._tokenService.GenerateToken(user);
        if (token is null)
            throw new BusinessException("Invalid Token");
        return token;
    }

    public async ValueTask<UserResponse> Register(CreateUserRequest userRequest)
    {
        long RegisterRoleId = 1;
        var user = new User(userRequest.Username, userRequest.Email, userRequest.Password, RegisterRoleId);
        await this._userRepository.AddAsync(user);
        var userResponse = this._mapper.Map<UserResponse>(user);
        return userResponse;
    }
}