using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;

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

    public User(string username , string email , string password , long userRoleId)
    {
        ValidationUsername(username);
        ValidationPassword(password);
        ValidationEmail(email);
        this.Username = username;
        this.Email = email;
        this.Password = password;
        IsEmailValid = false;
        this.UserRoleId = userRoleId;
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
        if (string.IsNullOrWhiteSpace(userName))
            throw new BusinessException("UserName notug'ri kiritildi ", nameof(Username), ErroEnum.ResourceInvalidField);
        if (userName.Length < 3 || userName.Length > 20)
            throw new BusinessException("UserName uzunligi 3 va 20 ta belgidan iborrat bulsin ", nameof(userName),
                ErroEnum.ResourceInvalidField);
    }

    private void ValidationEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new BusinessException("Email notug'ri kiritildi ", nameof(Email), ErroEnum.ResourceInvalidField);
        if (email.Length < 3 || email.Length > 50)
            throw new BusinessException("Email notug'ri kiritildi ", nameof(Email), ErroEnum.ResourceInvalidField);
    }

    public void ValidationPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new BusinessException("Password notug'ri kiritildi", nameof(Password), ErroEnum.ResourceInvalidField);
        if (password.Length < 8 || password.Length > 100)
            throw new BusinessException("Parol 8 va 100 ta belgidan iborat", nameof(Password),
                ErroEnum.ResourceInvalidField);
        if (!password.Any(char.IsNumber))
            throw new BusinessException("Parolda kamida bitta raqam bulish kerak", nameof(Password),
                ErroEnum.ResourceInvalidField);
        if (!password.Any(char.IsLetter))
            throw new BusinessException("Parolda kamida bitta belgi bulish kerak", nameof(Password),
                ErroEnum.ResourceInvalidField);
        if (!password.Any(char.IsLower))
            throw new BusinessException("Parolda kamida bitta harf bulish kerak", nameof(Password),
                ErroEnum.ResourceInvalidField);
        if (!password.Any(char.IsUpper))
            throw new BusinessException("Parolda kamida bitta harf bulish kerak", nameof(Password),
                ErroEnum.ResourceInvalidField);

        foreach (var value in password)
        {
            if (password.Where(x => x == value).Count() >= 3)
                throw new BusinessException("Parolni kiritishda 3 ta belgi bir xil bulmasin", nameof(Password),
                    ErroEnum.ResourceInvalidField);
        }
    }
}