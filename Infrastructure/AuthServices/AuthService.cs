using Application.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtTokenGenerator jwtTokenGenerator,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _logger = logger;
        }

        public async Task<string> RegisterAsync(string email, string password, string fullName)
        {
            try
            {
                _logger.LogInformation($"Registering new user {email}");
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FullName = fullName
                };

                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return "User registered successfully";
                }

                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Registering new user {email}: {ex.Message}");
                throw new ApplicationException($"User registration failed for {email} : {ex.Message}");
            }
            
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                _logger.LogInformation($"Login new user {email}");
                var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = _jwtTokenGenerator.GenerateToken(user, roles);
                    return token;
                }

                throw new ApplicationException("Invalid login attempt");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login user {email}: {ex.Message}");
                throw new ApplicationException($"Invalid login attempt: {ex.Message}");
            }
            
        }   
    }
}
