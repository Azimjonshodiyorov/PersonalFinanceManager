using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Domain.Entities.Common;

public class AuditableBaseEntity<T> : BaseEntity<T>
{
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    
}