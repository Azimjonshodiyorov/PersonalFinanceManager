using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.Revenue;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class RevenueService : IRevenueService
{
    private readonly IRevenueRepository _revenueRepository;
    private readonly IMapper _mapper;

    public RevenueService(IRevenueRepository revenueRepository , IMapper  mapper)
    {
        _revenueRepository = revenueRepository;
        _mapper = mapper;
    }
    public async ValueTask<RevenueResponse> GetByIdAndUserId(long id, long userId)
    {
        var revenue = await this._revenueRepository.GetByIdAndUserIdAsync(id, userId);
        if (revenue is null)
            throw new BusinessException("Invalid Id");
        var revenueResponse = this._mapper.Map<RevenueResponse>(revenue);
        return revenueResponse;
    }

    public async ValueTask<List<RevenueResponse>> GetByUserId(long userId)
    {
        var revenue = await this._revenueRepository.GetByUserIdAsync(userId);
        var revenueResponse = this._mapper.Map<List<RevenueResponse>>(revenue);
        return revenueResponse;
    }

    public async ValueTask<RevenueResponse> Create(CreateRevenueRequest revenueRequest, long userId)
    {
        var revenue = new Revenue(revenueRequest.Name, revenueRequest.RevenueCategoryId, revenueRequest.Date,
            revenueRequest.Value, revenueRequest.Description, userId);
        await this._revenueRepository.AddAsync(revenue);
        var revenueResponse = this._mapper.Map<RevenueResponse>(revenue);
        return revenueResponse;
    }

    public async ValueTask<RevenueResponse> Update(UpdateRevenueRequest revenueRequest, long id, long userId)
    {
        var revenue = await this._revenueRepository.GetByIdAndUserIdAsync(id, userId);
        if (revenue is null)
            throw new BusinessException("Invalid id");
        revenue.Update(revenueRequest.Name, revenueRequest.RevenueCategoryId, revenueRequest.Date, revenueRequest.Value,
            revenueRequest.Description, userId);
        await this._revenueRepository.UpdateAsync(revenue);
        var revenueResponse = this._mapper.Map<RevenueResponse>(revenue);
        return revenueResponse;
    }

    public async ValueTask<RevenueResponse> Delete(long id, long userId)
    {
        var revenue = await this._revenueRepository.GetByIdAndUserIdAsync(id, userId);
        if (revenue is null)
            throw new BusinessException("Invalid id");
        await this._revenueRepository.DeleteAsync(revenue);
        var revenueResponse = this._mapper.Map<RevenueResponse>(revenue);
        return revenueResponse;
    }
}