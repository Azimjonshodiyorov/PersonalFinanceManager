using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{id:long}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserResponse>> GetById(long id)
    {
        var user = await this._userService.GetById(id);
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
    [Route("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<UserResponse>>> GetAll()
    {
        var users = await this._userService.GetAll();

        return Ok(
            new Response
            {
                Success = true,
                Data = users,
            });
    }


    [HttpGet]
    [Route("Me")]
    public async Task<ActionResult<UserResponse>> GetMyUser()
    {
        var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var userResponse = await this._userService.GetById(userId);
        if (userResponse is null)
            return NotFound();

        return Ok(
            new Response
            {
                Success = true,
                Data = userResponse,
            });
    }
    
    
}