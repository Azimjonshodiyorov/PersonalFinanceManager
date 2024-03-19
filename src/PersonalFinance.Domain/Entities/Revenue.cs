using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;
public class Revenue : AuditableBaseEntity<long>
{
    public string Name { get; private set; }
        
    public DateTime Date { get; private set; }

    public decimal Value { get; private set; }

    public string Description { get; private set; }

    public long UserId { get; private set; }

    public virtual User User { get; private set; }
    
    public long RevenueCategoryId { get; private set; }

    public virtual RevenueCategory RevenueCategory { get; private set; }

    public Revenue()
    {
    }

    public Revenue(string name , long revenueCategoryId , DateTime? date , decimal value , string description , long userId)
    {
        ValidationName(name);
        ValidationValue(value);
        ValidationDescription(description);
        Name = name;
        Value = value;
        Date = date ?? DateTime.Now.Date;
        Description = description;
        UserId = userId;
        RevenueCategoryId = revenueCategoryId;
    }

    public void Update(string name, long revenueCategoryId, DateTime date, decimal value, string description,
        long userId)
    {
        ValidationName(name);
        ValidationValue(value);
        ValidationDescription(description);
        Name = name;
        RevenueCategoryId = revenueCategoryId;
        Date = date.Date;
        Value = value;
        Description = description;
    }


    private void ValidationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessException("Name noto'gri", nameof(Name), ErroEnum.ResourceInvalidField);
        if (name.Length < 3 || name.Length > 30)
            throw new BusinessException("Belgilar soni 3 va 30 ta yani shu oraliqda bulishi  kerak", nameof(Name),
                ErroEnum.ResourceInvalidField);
    }


    private void ValidationDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BusinessException("Name noto'gri", nameof(Description), ErroEnum.ResourceInvalidField);
        if (description.Length < 5 || description.Length > 100)
            throw new BusinessException("Belgilar soni 5 va 100 ta yani shu oraliqda bulishi  kerak", nameof(Description),
                ErroEnum.ResourceInvalidField);
    }

    private void ValidationValue(decimal value)
    {
        if (value <= 0)
            throw new BusinessException("Qiymat 0 ", nameof(Value), ErroEnum.ResourceInvalidField);
    }
}