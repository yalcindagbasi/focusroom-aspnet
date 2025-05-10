using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthService
{
    string HashPassword(string password);
    bool VerifyPassword(string hash, string password);
    string GenerateToken(User user);
}