using System.Text.Json.Serialization;
using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;

public class ExpenditureCategory : AuditableBaseEntity<long>
{
    public string  Name { get; private set; }
    public string Description { get; private set; }
    public long UserId { get; private set; }

    [JsonIgnore]
    public virtual User User { get; private set; }
    [JsonIgnore]
    public virtual List<Expenditure> Expenditures { get; private set; }

    public ExpenditureCategory()
    {
    }

    public ExpenditureCategory(string name , string description , long userId)
    {
        ValidationName(name);
        validationDescription(description);
        Name = name;
        Description = description;
        UserId = userId;
    }

    public void Update(string name, string description)
    {
        ValidationName(name);
        validationDescription(description);
        Name = name;
        Description = description;
    }


    private void ValidationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessException("Name notug'ri kiritildi", nameof(Name), ErroEnum.ResourceInvalidField);
        
        if (name.Length < 3 || name.Length > 30)
            throw new BusinessException("3 va 30 ta belgidan iborodat Name kiriting", nameof(Name),
                ErroEnum.ResourceInvalidField);
    }


    private void validationDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BusinessException("Description noto'ri ", nameof(Description), ErroEnum.ResourceInvalidField);

        if (description.Length < 5 || description.Length > 100)
            throw new BusinessException("5 va 100  ta belgidan iborat bulishi kerak", nameof(Description),
                ErroEnum.ResourceInvalidField);
    }
    
    
    
    
}