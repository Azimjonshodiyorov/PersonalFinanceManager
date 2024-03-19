using System.Text.Json.Serialization;
using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;

public class RevenueCategory : AuditableBaseEntity<long>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public long UserId { get; private set; }
    [JsonIgnore]
    public virtual User User { get; private set; }

    [JsonIgnore]
    public virtual List<Revenue> Revenues { get; private set; }

    public RevenueCategory()
    {
    }

    public RevenueCategory(string name , string description , long userId)
    {
        ValidationName(name);
        ValidationDescription(description);
        Name = name;
        Description = description;
        UserId = userId;
    }
    
    public void Update(string name, string description)
    {
        ValidationName(name);
        ValidationDescription(description);
        Name = name;
        Description = description;
    }
    
    public void ValidationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessException("Name is invalid", nameof(Name), ErroEnum.ResourceInvalidField);
        if (name.Length < 3 || name.Length > 30)
            throw new BusinessException("Name Invalid", nameof(Name), ErroEnum.ResourceInvalidField);
    }

    public void ValidationDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BusinessException("Decsription is Invalid", nameof(Description), ErroEnum.ResourceInvalidField);
        if(description.Length < 5 || description.Length > 100)
            throw new BusinessException("Decsription is Invalid", nameof(Description), ErroEnum.ResourceInvalidField);
    }
}