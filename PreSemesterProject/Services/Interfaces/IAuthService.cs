using PreSemesterProject.Models.ViewModels;

namespace PreSemesterProject.Services.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool ValidateLogin(LoginViewModel login);
    }
}
