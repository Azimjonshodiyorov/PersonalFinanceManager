using PersonalFinance.Application.ViewModel.Request.UserRole;
using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IUserRoleService
{
    ValueTask<UserRoleResponse> GetById(long id);
    ValueTask<List<UserRoleResponse>> GetAll();
    ValueTask<UserRoleResponse> Create(CreateUserRoleRequest userRoleRequest);
    ValueTask<UserRoleResponse> Update(UpdateUserRoleRequest userRoleRequest , long id);
    ValueTask<UserRoleResponse> Delete(long id);
}