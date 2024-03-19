using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Domain.Entities.Common;

public class BaseEntity<T>
{
    public T Id { get; set; }
}