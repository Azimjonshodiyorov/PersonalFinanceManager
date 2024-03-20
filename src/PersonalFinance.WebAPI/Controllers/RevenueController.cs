using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;

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
}