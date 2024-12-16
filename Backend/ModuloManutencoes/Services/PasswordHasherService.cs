using Microsoft.AspNetCore.Identity;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<string> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        }
    }
}
