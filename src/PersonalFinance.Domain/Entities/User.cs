using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PersonalFinance.Domain.Entities.Common;

namespace PersonalFinance.Domain.Entities;

[Table("user")]
public class User : AuditableBaseEntity<long>
{
    public string Username { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public bool IsEmailValid { get; private set; }

    public long UserRoleId { get; private set; }

    public virtual UserRole UserRole { get; private set; }

    [JsonIgnore]
    public virtual List<Revenue> Revenues { get; private set; }
    [JsonIgnore]
    public virtual List<Expenditure> Expenditures { get; private set; }

    [JsonIgnore]
    public virtual List<RevenueCategory> RevenueCategories { get; private set; }

    [JsonIgnore]
    public virtual List<ExpenditureCategory> ExpenditureCategories { get; private set; }

    public User() { }

    public User(string username , string email , string password , string userRoleId)
    {
        this.Username = username;
        this.Email = email;
        this.Password = password;
        IsEmailValid = false;
        userRoleId = userRoleId;
        CreateAt = DateTime.UtcNow;
    }

    public void UpdateIsEmailValid()
    {
        IsEmailValid = true;
    }

    public void UpdateUserRole(long roleId)
    {
        UserRoleId = roleId;
    }

    public bool IsValidLoginPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, this.Password);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt
            .HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }

    private void ValidationUsername(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
        }
        // throw new Busi
    }
}