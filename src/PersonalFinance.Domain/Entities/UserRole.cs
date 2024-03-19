using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;

public class UserRole : AuditableBaseEntity<long>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public virtual List<User> Users { get; private set; }

    public UserRole()
    {
    }

    public UserRole(string name , string description)
    {
        ValidationName(name);
        ValidationDescription(description);
        Name = name;
        Description = description;
    }

    public void Update(string name, string description)
    {
        ValidationName(name);
        ValidationDescription(description);
        this.Name = name;
        this.Description = description;
    }
    public void ValidationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessException("Name is invalid", nameof(name), ErroEnum.ResourceInvalidField);
        if (name.Length < 3 || name.Length > 30)
            throw new BusinessException("Name Invalid", nameof(name), ErroEnum.ResourceInvalidField);
    }

    public void ValidationDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BusinessException("Decsription is Invalid", nameof(description), ErroEnum.ResourceInvalidField);
        if(description.Length < 5 || description.Length > 100)
            throw new BusinessException("Decsription is Invalid", nameof(description), ErroEnum.ResourceInvalidField);
    }
}