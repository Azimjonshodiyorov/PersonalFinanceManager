using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.Expenditure;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class ExpenditureService : IExpenditureService
{
    private readonly IExpendtureRepository _expendtureRepository;
    private readonly IMapper _mapper;

    public ExpenditureService(IExpendtureRepository  expendtureRepository , IMapper mapper)
    {
        _expendtureRepository = expendtureRepository;
        _mapper = mapper;
    }
    public async ValueTask<ExpenditureResponse> GetByIdAndUserId(long id, long userId)
    {
        var expenditure = await this._expendtureRepository.GetByIdAndUserIdAsync(id, userId);
        var expenditureResponse = this._mapper.Map<ExpenditureResponse>(expenditure);
        return expenditureResponse;
    }

    public async ValueTask<List<ExpenditureResponse>> GetByUserId(long userId)
    {
        var expenditure = await this._expendtureRepository.GetByUserIdAsync(userId);
        var expenditureResponse = this._mapper.Map<List<ExpenditureResponse>>(expenditure);
        return expenditureResponse;
    }

    public async ValueTask<ExpenditureResponse> Create(CreateExpenditureRequest expenditureRequest, long userId)
    {
        var expenditure = new Expenditure(expenditureRequest.Name, expenditureRequest.ExpenditureCategoryId,
            expenditureRequest.Date, expenditureRequest.Value, expenditureRequest.Description, userId);
        await this._expendtureRepository.AddAsync(expenditure);
        var expenditureResponse = this._mapper.Map<ExpenditureResponse>(expenditure);
        return expenditureResponse;
    }

    public async ValueTask<ExpenditureResponse> Update(UpdateExpendidureRequest expendidureRequest, long id, long userId)
    {
        var expenditure = await this._expendtureRepository.GetByIdAndUserIdAsync(id, userId);
        if (expenditure is null)
            throw new BusinessException("Invalid Id");
        expenditure.Update(expendidureRequest.Name , expendidureRequest.ExpenditureCategoryId , expendidureRequest.Date , expendidureRequest.Value , expendidureRequest.Description);
        await this._expendtureRepository.UpdateAsync(expenditure);
        var expenditureResponse = this._mapper.Map<ExpenditureResponse>(expenditure);
        return expenditureResponse;
    }

    public async ValueTask<ExpenditureResponse> Delete(long id, long userId)
    {
        var expenditure = await this._expendtureRepository.GetByIdAndUserIdAsync(id, userId);

        if (expenditure is null)
            throw new BusinessException("Invalid id");
        await this._expendtureRepository.DeleteAsync(expenditure);
        var expenditureResponse = this._mapper.Map<ExpenditureResponse>(expenditure);
        return expenditureResponse;
    }
}