using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.UserRole;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _roleService;

    public UserRoleController(IUserRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("UserRoleGetBy{id:long}")]
    public async Task<ActionResult<UserRoleResponse>> GetById(long id)
    {
        var user = await this._roleService.GetById(id);
        if (user is null)
            return NotFound();
        return Ok(
            new Response
            {
                Success = true,
                Data = user,
            });
    }

    [HttpGet]
    [Route("UserRoleGetAll")]
    public async Task<ActionResult<UserRoleResponse>> GetAll()
    {
        var users = await this._roleService.GetAll();
        return Ok
        (
            new Response
            {
                Success = true,
                Data = users,
            });
    }


    [HttpPost]
    [Route("AddUserRole")]
    public async Task<ActionResult> Create(CreateUserRoleRequest userRoleRequest)
    {
        if (userRoleRequest is null)
            throw new ArgumentNullException(nameof(userRoleRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Requst", nameof(CreateUserRoleRequest),
                ErroEnum.ResourceBadRequest));
        var userRole = await this._roleService.Create(userRoleRequest);

        return Ok(
            new Response
            {
                Success = true,
                Data = userRole,
            });
    }

    [HttpPut]
    [Route("UserRoleUpdate{id:long}")]
    public async Task<ActionResult> Update(UpdateUserRoleRequest userRoleRequest, long id)
    {
        if (userRoleRequest is null)
            throw new ArgumentNullException(nameof(UpdateUserRoleRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Requset", nameof(UpdateUserRoleRequest),
                ErroEnum.ResourceBadRequest));
        var userRole = await this._roleService.Update(userRoleRequest, id);

        return Ok(
            new Response
            {
                Success = true,
                Data = userRole,
            });
    }


    [HttpDelete]
    [Route("{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        var userRole = await this._roleService.Delete(id);
        return Ok(
            new Response
            {
                Success = true,
                Data = userRole,
            });
    }
    
}