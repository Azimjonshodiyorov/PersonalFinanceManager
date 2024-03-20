using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.User;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;
using LoginRequest = PersonalFinance.Application.ViewModel.Request.User.LoginRequest;

namespace PersonalFinance.WebAPI.Controllers;

[ApiController]
[Route("api/Account")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<Token>> Login(LoginRequest login)
    {
        if (login is null)
            throw new ArgumentNullException(nameof(login));
        if (!ModelState.IsValid)
            return BadRequest(
                new BusinessException("Invalid Requst", nameof(LoginRequest), ErroEnum.ResourceBadRequest));
        var token = await this._authenticationService.Login(login);
        return Ok(
            new Response
            {
            Success = true,
            Data = token,
            }
        );
    }


    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<Token>> Register(CreateUserRequest userRequest)
    {
        if (userRequest is null)
            throw new ArgumentNullException(nameof(userRequest));
        if (!ModelState.IsValid)
            throw new BusinessException("Invalid Requst", nameof(CreateUserRequest), ErroEnum.ResourceBadRequest);
        var user = await this._authenticationService.Register(userRequest);
        
        return Ok(
            new Response
            {
                Success = true,
                Data = user,
            });
    }
}