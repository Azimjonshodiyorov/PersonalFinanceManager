using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.Interfaces;

public interface ITokenService
{
    public Token GenerateToken(User user);
}