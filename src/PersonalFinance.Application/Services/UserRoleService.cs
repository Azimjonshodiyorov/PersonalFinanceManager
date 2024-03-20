using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.UserRole;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public UserRoleService(IUserRoleRepository roleRepository , IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async ValueTask<UserRoleResponse> GetById(long id)
    {
        var userRole = await this._roleRepository.GetByIdAsync(id);
        var userRoleResponse = this._mapper.Map<UserRoleResponse>(userRole);
        return userRoleResponse;
    }

    public async ValueTask<List<UserRoleResponse>> GetAll()
    {
        var userRole = await this._roleRepository.GetAllAsNoTrackingAsync();
        var userRoleRespone = this._mapper.Map<List<UserRoleResponse>>(userRole);
        return userRoleRespone;
    }

    public async ValueTask<UserRoleResponse> Create(CreateUserRoleRequest userRoleRequest)
    {
        var userRole = new UserRole(userRoleRequest.Name, userRoleRequest.Description);
        await this._roleRepository.AddAsync(userRole);
        var userRespone = this._mapper.Map<UserRoleResponse>(userRole);
        return userRespone;
    }

    public async ValueTask<UserRoleResponse> Update(UpdateUserRoleRequest userRoleRequest, long id)
    {
        var userRole = await this._roleRepository.GetByIdAsync(id);
        if (userRole == null)
            throw new BusinessException("Invalid id");
        userRole.Update(userRole.Name , userRole.Description);
        await this._roleRepository.UpdateAsync(userRole);
        var userRoleResponse = this._mapper.Map<UserRoleResponse>(userRole);
        return userRoleResponse;
    }

    public async ValueTask<UserRoleResponse> Delete(long id)
    {
        var userRole = await this._roleRepository.GetByIdAsync(id);
        if (userRole == null)
            throw new BusinessException("Invalid Id");
        await this._roleRepository.DeleteAsync(userRole);
        var userResponse = this._mapper.Map<UserRoleResponse>(userRole);
        return userResponse;
    }
}