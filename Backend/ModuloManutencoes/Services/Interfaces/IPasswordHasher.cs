using Microsoft.AspNetCore.Identity;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword);
    }
}
