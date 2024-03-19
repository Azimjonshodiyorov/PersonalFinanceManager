using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Exception;

namespace PersonalFinance.Domain.Entities;

public class Expenditure : AuditableBaseEntity<long>
{
       public string Name { get; private set; }
    
        public decimal Value { get; private set; }

        public string Description { get; private set; }

        public long UserId { get; private set; }

        public virtual User User { get; private set; }

        public int ExpenditureCategoryId { get; private set; }

        public virtual ExpenditureCategory ExpenditureCategory { get; private set; }


        protected Expenditure() { }

        public Expenditure(string name, int expenditureCategoryId, DateTime? date, decimal value, string description, int userId) 
        {
            ValidationName(name);
            ValidationValue(value);
            ValidationDescription(description);
            Name = name;
            ExpenditureCategoryId = expenditureCategoryId;
            CreateAt = date ?? DateTime.Now.Date;
            Value = value;
            Description = description;
            UserId = userId;
        }

        public void Update(string name, int expenditureCategoryId, DateTime date, decimal value, string description) 
        {
            ValidationName(name);
            ValidationValue(value);
            ValidationDescription(description);
            Name = name;
            ExpenditureCategoryId = expenditureCategoryId;
            CreateAt = date.Date;
            Value = value;
            Description = description;
        }


        private void ValidationName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Notug'ri name kiritildi", nameof(Name), ErroEnum.ResourceInvalidField);

            if (name.Length < 3 || name.Length > 30)
                throw new BusinessException("3 va 30 ta belgi kiriting", nameof(Name), ErroEnum.ResourceInvalidField);
        }

        private void ValidationDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
                throw new BusinessException("Description notug'ri", nameof(Description), ErroEnum.ResourceInvalidField);

            if (description.Length < 5 || description.Length > 100)
                throw new BusinessException("5 va 100 ta belgidan  iborat bulsin", nameof(Description), ErroEnum.ResourceInvalidField);
        }

        private void ValidationValue(decimal value)
        {
            if(value <= 0)
                throw new BusinessException("qiymat kiritilmadi", nameof(Value), ErroEnum.ResourceInvalidField);
        }
}