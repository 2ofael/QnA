using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsTeacherAsync(TeacherRegistrationViewModel model)
        {
            var user = new Teacher { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }


        public async Task<IdentityResult> RegisterAsStudentAsync(StudentRegistrationViewModel model)
        {
            var user = new Student { UserName = model.Email, Email = model.Email, IdCardNumber = model.IdCardNumber, InstituteName = model.InstituteName };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }



        public async Task<SignInResult> LoginAsync(LogInViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
