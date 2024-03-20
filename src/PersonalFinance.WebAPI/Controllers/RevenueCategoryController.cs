using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.RevenueCategory;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RevenueCategoryController : ControllerBase
{
    private readonly IRevenueCategoryService _categoryService;

    public RevenueCategoryController(IRevenueCategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<ActionResult<RevenueCategoryResponse>> GetById(long id)
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueCategoryResponse = await this._categoryService.GetByIdAndUserId(id, userId);
        if (revenueCategoryResponse is null)
            return NotFound();
        return Ok(
            new Response
            {
                Success = true,
                Data = revenueCategoryResponse,
            });
    }


    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<RevenueCategoryResponse>> Get()
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueCategoryResponse = await this._categoryService.GetByUserId(userId);
        if (revenueCategoryResponse is null)
            return NotFound();

        return Ok(
            new Response
            {
                Success = true,
                Data = revenueCategoryResponse,
            });
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<RevenueCategoryResponse>> Create(CreateRevenueCategoryRequest revenueCategoryRequest)
    {
        if (revenueCategoryRequest is null)
            throw new ArgumentNullException(nameof(revenueCategoryRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Requst", nameof(CreateRevenueCategoryRequest),
                ErroEnum.ResourceBadRequest));
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueCategoryResponse = await this._categoryService.Create(revenueCategoryRequest, userId);
        return Ok(
            new Response
            {
                Success = true,
                Data = revenueCategoryRequest
            });
    }

    [HttpPut]
    [Route("{id:long}")]
    public async Task<ActionResult<RevenueCategoryResponse>> Update(UpdateRevenueCategoryRequest revenueCategoryRequest,
        long id)
    {
        if (revenueCategoryRequest is null)
            throw new ArgumentNullException(nameof(revenueCategoryRequest));
        if (!ModelState.IsValid)
            return BadRequest(new BusinessException("Invalid Request", nameof(revenueCategoryRequest),
                ErroEnum.ResourceBadRequest));
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueCategoryResponse = await this._categoryService.Update(revenueCategoryRequest, id, userId);

        return Ok(
            new Response
            {
                Success = true,
                Data = revenueCategoryRequest,
            });
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<ActionResult<RevenueCategoryResponse>> Delete(long id)
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var revenueCategoryResponse = await this._categoryService.Delete(id, userId);

        return Ok(
            new Response
            {
                Success = true,
                Data = revenueCategoryResponse
            });
    }
}