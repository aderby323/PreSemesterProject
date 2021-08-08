

using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Services.Interfaces;

namespace PreSemesterProject.Services
{
    public class AuthService : IAuthService
    {
        public string HashPassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateLogin(LoginViewModel login)
        {
            if (login is null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)) { return false; }

            if (login.Username.Equals("aderby") && login.Password.Equals("test"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
