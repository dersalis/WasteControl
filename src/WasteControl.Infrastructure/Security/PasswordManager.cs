using Microsoft.AspNetCore.Identity;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.Security
{
    public class PasswordManager : IPasswordManager
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordManager()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string Secure(string password) => _passwordHasher.HashPassword(default, password);

        public bool Validate(string password, string securedPassword) => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) 
            is PasswordVerificationResult.Success;
    }
}