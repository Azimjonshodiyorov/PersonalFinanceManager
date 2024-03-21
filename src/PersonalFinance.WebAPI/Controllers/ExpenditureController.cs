using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.Expenditure;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Application.ViewModel.Response.CommandResponse;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExpenditureController : ControllerBase
{
    private readonly IExpenditureService _expenditureService;

    public ExpenditureController(IExpenditureService expenditureService)
    {
        _expenditureService = expenditureService;
    }


    [HttpGet]
    [Route("{id:long}")]
    public async Task<ActionResult<ExpenditureResponse>> GetById(long id)
    {
        var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        var expendituerResponse = await this._expenditureService.GetByIdAndUserId(id, userId);
        if (expendituerResponse is null)
            return BadRequest();
        return Ok(
            new Response
            {
                Success = true,
                Data = expendituerResponse,
            });
    }
    
    
       [HttpGet]
       [Route("")]
       public async Task<ActionResult<List<ExpenditureResponse>>> Get()
       {
           var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

           var expenditureResponses = await _expenditureService.GetByUserId(userId);

           if(expenditureResponses is null)
               return NotFound();

           return Ok
           (
               new Response
               {
                   Success = true,
                   Data = expenditureResponses
               }
           );
       }

       [HttpPost]
       [Route("Add")]
       public async Task<ActionResult<ExpenditureResponse>> Create(CreateExpenditureRequest createExpenditureRequest)
       {
           if (createExpenditureRequest is null)
               throw new ArgumentNullException(nameof(createExpenditureRequest));
           
           if (!ModelState.IsValid)
               return BadRequest(new BusinessException("Invalid Request", nameof(CreateExpenditureRequest), ErroEnum.ResourceBadRequest));

           var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

           var expenditureResponse = await _expenditureService.Create(createExpenditureRequest, userId);

           return Ok
           (
               new Response
               {
                   Success = true,
                   Data = expenditureResponse
               }
           );;
       }

       [HttpPut]
       [Route("{id:long}")]
       public async Task<ActionResult<ExpenditureResponse>> Update(UpdateExpendidureRequest updateExpenditureRequest, long id)
       {
           if (updateExpenditureRequest is null)
               throw new ArgumentNullException(nameof(updateExpenditureRequest));
           
           if (!ModelState.IsValid)
               return BadRequest(new BusinessException("Invalid Request", nameof(UpdateExpendidureRequest), ErroEnum.ResourceBadRequest));

           var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

           var expenditureResponse = await _expenditureService.Update(updateExpenditureRequest, id, userId);

           return Ok
           (
               new Response
               {
                   Success = true,
                   Data = expenditureResponse
               }
           );;
       }

       [HttpDelete]
       [Route("{id:long}")]
       public async Task<ActionResult<ExpenditureResponse>> Delete(long id)
       {
           var userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

           var expenditureResponse = await _expenditureService.Delete(id, userId);

           return Ok
           (
               new Response
               {
                   Success = true,
                   Data = expenditureResponse
               }
           );;
       }
}