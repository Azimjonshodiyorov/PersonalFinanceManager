using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository , IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async ValueTask<UserResponse> GetById(long id)
    {
        var user = await this._userRepository.GetByIdAsync(id);
        var userResponse = this._mapper.Map<UserResponse>(user);
        return userResponse;
    }

    public async ValueTask<List<UserResponse>> GetAll()
    {
        var users = await this._userRepository.GetAllAsync();
        var userResponse = this._mapper.Map<List<UserResponse>>(users);
        return userResponse;
    }
}