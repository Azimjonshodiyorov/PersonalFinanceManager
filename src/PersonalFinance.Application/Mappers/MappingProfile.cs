using AutoMapper;
using PersonalFinance.Application.ViewModel.Response;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserRole, UserRoleResponse>();
        CreateMap<RevenueCategory, RevenueCategoryResponse>();
        CreateMap<ExpenditureCategory, ExpenditureCategoryResponse>();
        CreateMap<Revenue, RevenueResponse>();
        CreateMap<Expenditure, ExpenditureResponse>();
    }
}