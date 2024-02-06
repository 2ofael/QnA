using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResult> LoginAsync(LogInViewModel model);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsStudentAsync(StudentRegistrationViewModel model);
        Task<IdentityResult> RegisterAsTeacherAsync(TeacherRegistrationViewModel model);
    }
}