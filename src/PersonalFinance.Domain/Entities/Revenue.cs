using System.ComponentModel.DataAnnotations.Schema;
using PersonalFinance.Domain.Entities.Common;

namespace PersonalFinance.Domain.Entities;
[Table("income")]
public class Revenue : AuditableBaseEntity<long>
{
    [Column("company")]
    public string Company { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("comment")]
    public string Comment { get; set; }

    [Column("category_id")]
    public long CategoryId { get; set; }
    
    [Column("additional_Income_id")]
    public long AdditionalIncomeId { get; set; }
    
    
    
}