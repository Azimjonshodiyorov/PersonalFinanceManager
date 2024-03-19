using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.ViewModel.Response;

public class UserRoleResponse
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}