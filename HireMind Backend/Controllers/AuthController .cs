using HireMind.Application.DTO;
using HireMind.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HireMind_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.RegisterAsync(request);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }   
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.LoginAsync(request);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        

        [HttpPost("addrole")]
        [Authorize]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.AddRoleAsync(request);
            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(request);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh([FromBody] TokenRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.RefreshTokenAsync(request);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst("uid")?.Value;
            if (userId == null)
                return BadRequest("Invalid user");

            var result = await authService.LogoutAsync(userId);

            if (!result)
                return BadRequest("Logout failed");

            return Ok(new { Message = "Logged out successfully" });
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            if (userId == null)
                return Unauthorized();

            var result = await authService.ChangePasswordAsync(userId, request);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Password changed successfully.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.ForgotPasswordAsync(request.Email);

            return Ok(new {Message = result});
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.ResetPasswordAsync(request);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Password has been reset successfully.");
        }


        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await authService.VerifyEmailAsync(request);

            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok("Email verified successfully.");
        }

        [HttpPost("resend-verification")]
        public async Task<IActionResult> ResendVerification([FromBody] ResendVerificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.ResendVerificationEmailAsync(request);


            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok("The Verification is sent");
        }
        [HttpGet("Me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst("uid")?.Value;
            if (userId == null)
                return BadRequest("Invalid user");
            var result = await authService.GetCurrentUserAsync(userId);
            if (result == null)
                return NotFound("User not found");
            return Ok(result);
        }
    }
}
