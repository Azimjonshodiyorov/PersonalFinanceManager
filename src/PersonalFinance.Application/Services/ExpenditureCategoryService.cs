using AutoMapper;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Exception;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.Services;

public class ExpenditureCategoryService : IExpenditureCategoryService
{
    private readonly IExpendtureCategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ExpenditureCategoryService(IExpendtureCategoryRepository categoryRepository , IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async ValueTask<ExpenditureCategoryResponse> GetByIdAndUserId(long id, long userId)
    {
        var expenditureCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        var expenditureCategoryResponse = this._mapper.Map<ExpenditureCategoryResponse>(expenditureCategory);
        return expenditureCategoryResponse;
    }

    public async ValueTask<List<ExpenditureCategoryResponse>> GetByUserId(long userId)
    {
        var expenditureCategory = await this._categoryRepository.GetByUserIdAsNoTrackingAsync(userId);
        var expenditureCategoryResponse = this._mapper.Map<List<ExpenditureCategoryResponse>>(expenditureCategory);
        return expenditureCategoryResponse;
    }

    public async ValueTask<ExpenditureCategoryResponse> Create(CreateExpendditureCategoryRequest expendditureCategoryRequest, long id, long userId)
    {
        var expendituerCategory = new ExpenditureCategory(expendditureCategoryRequest.Name,
            expendditureCategoryRequest.Description, userId);
        await this._categoryRepository.AddAsync(expendituerCategory);
        var expendituerCategoryResponse = this._mapper.Map<ExpenditureCategoryResponse>(expendituerCategory);
        return expendituerCategoryResponse;

    }

    public async ValueTask<ExpenditureCategoryResponse> Update(UpdateExpenditureCategoryRequest expenditureCategoryRequest, long id, long userId)
    {
        var expenditureCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        if (expenditureCategory is null)
            throw new BusinessException("Invliad Id");
        expenditureCategory.Update(expenditureCategoryRequest.Name, expenditureCategoryRequest.Description);
        await this._categoryRepository.UpdateAsync(expenditureCategory);
        var expendituerCategoryResponse = this._mapper.Map<ExpenditureCategoryResponse>(expenditureCategory);
        return expendituerCategoryResponse;
    }

    public async ValueTask<ExpenditureCategoryResponse> Delete(long id, long userId)
    {
        var expendituerCategory = await this._categoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
        if (expendituerCategory is null)
            throw new BusinessException("Invlid Id");
        await this._categoryRepository.DeleteAsync(expendituerCategory);
        var expendituerCategoryResponse = this._mapper.Map<ExpenditureCategoryResponse>(expendituerCategory);
        return expendituerCategoryResponse;
    }
}