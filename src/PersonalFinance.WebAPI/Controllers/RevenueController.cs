using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.Revenue;
using PersonalFinance.Application.ViewModel.Request.UserRole;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RevenueController : ControllerBase
{
    private readonly IRevenueService _revenueService;

    public RevenueController(IRevenueService revenueService)
    {
        _revenueService = revenueService;
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<ActionResult<RevenueResponse>> GetById(long id)
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueResponse = await this._revenueService.GetByIdAndUserId(id, userId);
        if (revenueResponse is null)
            return NotFound();
        return Ok(
            new Response
            {
                Success = true,
                Data = revenueResponse,
            });
    }

    [HttpGet]
    [Route("User")]
    public async Task<ActionResult<RevenueResponse>> Get()
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var userResponse = await this._revenueService.GetByUserId(userId);

        if (userResponse is null)
            return NotFound();
        return Ok(
            new Response
            {
                Success = true,
                Data = userResponse,
            });
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<RevenueResponse>> Create(CreateRevenueRequest revenueRequest)
    {
        if (revenueRequest is null)
            throw new ArgumentNullException(nameof(revenueRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Requst", nameof(CreateUserRoleRequest),
                ErroEnum.ResourceBadRequest));
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueResponse = await this._revenueService.Create(revenueRequest, userId);
        return Ok(
            new Response
            {
                Success = true,
                Data = revenueRequest,
            });
    }

    [HttpPut]
    [Route("Update{id:long}")]
    public async Task<ActionResult<RevenueResponse>> Update(UpdateRevenueRequest revenueRequest, long id)
    {
        if (revenueRequest is null)
            throw new ArgumentNullException(nameof(revenueRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Requst", nameof(UpdateRevenueRequest),
                ErroEnum.ResourceBadRequest));
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueResponse = await this._revenueService.Update(revenueRequest, id, userId);

        return Ok(
            new Response
            {
                Success = true,
                Data = revenueResponse,
            });
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<ActionResult<RevenueResponse>> Delete(long id)
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueResponse = await this._revenueService.Delete(id, userId);

        return Ok(
            new Response
            {
                Success = true,
                Data = revenueResponse,
            });
    }
    
    
    
}