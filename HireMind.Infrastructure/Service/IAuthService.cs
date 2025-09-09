using HireMind.Application.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Infrastructure.Service
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthModel> RefreshTokenAsync(TokenRequestModel model);
        Task<bool> LogoutAsync(string userId);
        Task<IdentityResult> ChangePasswordAsync(string userId, ChangePasswordModel model);
        Task<string> ForgotPasswordAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
        Task<IdentityResult> VerifyEmailAsync(VerifyEmailRequest model);
        Task<IdentityResult> ResendVerificationEmailAsync(ResendVerificationRequest model);
    }
}
