using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Domain.Entities.Common;

public class AuditableBaseEntity<T> : BaseEntity<T>
{
    [Column("create_at")]
    public DateTime CreateAt { get; set; }
    [Column("update_at")]
    public DateTime UpdateAt { get; set; }
    
}