using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExpenditureCategoryController : ControllerBase
{
        private readonly IExpenditureCategoryService _expenditureCategoryService;

        public ExpenditureCategoryController(IExpenditureCategoryService expenditureCategoryService)
        {
            _expenditureCategoryService = expenditureCategoryService;
        }

        
        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> GetById(long id)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.GetByIdAndUserId(id, userId);

            if(expenditureCategoryResponse == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> Get()
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponses = await _expenditureCategoryService.GetByUserId(userId);

            if(expenditureCategoryResponses == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponses
                }
            );
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Create(CreateExpendditureCategoryRequest createExpenditureCategoryRequest , long id)
        {
            if (createExpenditureCategoryRequest == null)
                throw new ArgumentNullException(nameof(createExpenditureCategoryRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(CreateExpendditureCategoryRequest), ErroEnum.ResourceBadRequest));

            var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Create(createExpenditureCategoryRequest , id,userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<ActionResult> Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest, long id)
        {
            if (updateExpenditureCategoryRequest == null)
                throw new ArgumentNullException(nameof(updateExpenditureCategoryRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(UpdateExpenditureCategoryRequest), ErroEnum.ResourceBadRequest));

            var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Update(updateExpenditureCategoryRequest, id, userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> Delete(long id)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Delete(id, userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }
}