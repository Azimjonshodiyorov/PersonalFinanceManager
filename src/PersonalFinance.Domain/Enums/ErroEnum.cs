using System.ComponentModel;

namespace PersonalFinance.Domain.Enums;

public enum ErroEnum
{
    [Description("Not found")]
    ResourceNotFound = 1,

    [Description("Invalid field")]
    ResourceInvalidField = 2,

    [Description("Bad request")]
    ResourceBadRequest = 3
}