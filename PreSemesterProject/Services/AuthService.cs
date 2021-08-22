using PreSemesterProject.Models.DBModels;
using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Repository;
using PreSemesterProject.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PreSemesterProject.Services
{
    public class AuthService : IAuthService
    {

        private FakeRepository _repository;
        private readonly VolunteerManagementSystemContext _context;

        public AuthService(FakeRepository repository, VolunteerManagementSystemContext context)
        {
            _repository = repository;
            _context = context;
        }

        public string HashPassword(string password, string salt)
        {
            var byteResult = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public User ValidateLogin(LoginViewModel login)
        {
            if (login is null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)) { return default; }

            User user = _context.Users
                .Where(x => x.Username.Equals(login.Username))
                .FirstOrDefault();

            if (user is null || !user.PasswordHash.Equals(HashPassword(login.Password, user.Salt))) { return default; }

            return user;
        }
    }
}
