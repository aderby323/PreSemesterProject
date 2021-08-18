using PreSemesterProject.Models;
using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Repository;
using PreSemesterProject.Services.Interfaces;

namespace PreSemesterProject.Services
{
    public class AuthService : IAuthService
    {

        private FakeRepository _repository;

        public AuthService(FakeRepository repository)
        {
            _repository = repository;
        }

        public string HashPassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public User ValidateLogin(LoginViewModel login)
        {
            if (login is null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)) { return default; }

            User user = _repository.Users.Find(x => x.Username.Equals(login.Username));

            if (user is null) { return default; }

            if (user.Password.Equals(login.Password))
            {
                return user;
            }
            else
            {
                return default;
            }
        }
    }
}
