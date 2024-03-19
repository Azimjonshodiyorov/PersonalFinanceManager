using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.ViewModel.Response;

public class UserResponse
{
    public long Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public bool IsEmailValid { get; set; }

    public DateTime CreationDate { get; set; }

    public long UserRoleId { get; set; }

    public UserRole UserRole { get; set; }
}