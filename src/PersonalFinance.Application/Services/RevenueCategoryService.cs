using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.RevenueCategory;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class RevenueCategoryService : IRevenueCategoryService
{
    private readonly IRevenueCategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public RevenueCategoryService(IRevenueCategoryRepository categoryRepository , IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async ValueTask<RevenueCategoryResponse> GetByIdAndUserId(long id, long userId)
    {
        var revenueCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        var revenueCategoryResponse = this._mapper.Map<RevenueCategoryResponse>(revenueCategory);
        return revenueCategoryResponse;
    }

    public async ValueTask<List<RevenueCategoryResponse>> GetByUserId(long userId)
    {
        var revenueCategory = await this._categoryRepository.GetByUserIdAsNoTrackingAsync(userId);
        var revenueCategoryResponse = this._mapper.Map<List<RevenueCategoryResponse>>(revenueCategory);
        return revenueCategoryResponse;
    }

    public async ValueTask<RevenueCategoryResponse> Create(CreateRevenueCategoryRequest revenueCategoryRequest, long userId)
    {
        var revenueCategory =
            new RevenueCategory(revenueCategoryRequest.Name, revenueCategoryRequest.Description, userId);
        await this._categoryRepository.AddAsync(revenueCategory);
        var revenueCategoryResponse = this._mapper.Map<RevenueCategoryResponse>(revenueCategory);
        return revenueCategoryResponse;
    }

    public async ValueTask<RevenueCategoryResponse> Update(UpdateRevenueCategoryRequest revenueCategoryRequest, long id, long userId)
    {
        var revenueCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        if (revenueCategory is null)
            throw new BusinessException("Invalid id");
        revenueCategory.Update(revenueCategoryRequest.Name , revenueCategoryRequest.Description);
        await this._categoryRepository.UpdateAsync(revenueCategory);
        var revenueCategoryResponse = this._mapper.Map<RevenueCategoryResponse>(revenueCategory);
        return revenueCategoryResponse;
    }

    public async ValueTask<RevenueCategoryResponse> Delete(long id, long userId)
    {
        var revenueCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        if (revenueCategory is null)
            throw new BusinessException("Invalid Id");
        await this._categoryRepository.DeleteAsync(revenueCategory);
        var revenueCategoryResponse = this._mapper.Map<RevenueCategoryResponse>(revenueCategory);
        return revenueCategoryResponse;
    }
}