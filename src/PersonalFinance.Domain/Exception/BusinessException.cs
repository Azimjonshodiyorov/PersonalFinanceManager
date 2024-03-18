using PersonalFinance.Domain.Enums;

namespace PersonalFinance.Domain.Exception;

public class BusinessException : System.Exception
{
    public string Param { get; set; }
    public ErroEnum ErroEnum { get; set; }

    public BusinessException()
    {
    }

    public BusinessException( string message) : base(message)
    {
    }

    public BusinessException(string message ,string param) : base(message)
    {
        this.Param = param;
    }

    public BusinessException(string message , string param , ErroEnum erroEnum) : base(message)
    {
        this.Param = param;
        this.ErroEnum = erroEnum;
    }
    
}