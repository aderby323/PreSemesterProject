using PreSemesterProject.Models;
using PreSemesterProject.Models.ViewModels;

namespace PreSemesterProject.Services.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        User ValidateLogin(LoginViewModel login);
    }
}
