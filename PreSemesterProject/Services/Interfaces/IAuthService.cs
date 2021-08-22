using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Models.DBModels;

namespace PreSemesterProject.Services.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password, string salt);
        string GenerateSalt();
        User ValidateLogin(LoginViewModel login);
    }
}
