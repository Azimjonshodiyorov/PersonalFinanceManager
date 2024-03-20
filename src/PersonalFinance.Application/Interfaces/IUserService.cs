using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IUserService
{
    ValueTask<UserResponse> GetById(long id);
    ValueTask<List<UserResponse>> GetAll();
}