using Domain.Entities;
using Domain.UseCase.Account;
using Domain.UseCase.Repository;
using Domain.UseCase.Result;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Account : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IRepositoryAsync<User> _userRepository;

        public Account(
            UserManager<ApplicationUser> userManager,
            IRepositoryAsync<User> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<ExecutionResult> CreateAsync(UserAccount userAccount)
        {
            ArgumentNullException.ThrowIfNull(userAccount);
            var user = new User
            {
                Email = userAccount.Email,
                Name = userAccount.Name,
            };

            var appUser = new ApplicationUser
            {
                UserName = userAccount.Email,
                Email = userAccount.Email,
                User = user
            };

            var result = await _userManager.CreateAsync(appUser, userAccount.Password);

            var errors = new List<ExecutionError>();
            if (!result.Succeeded)
            {
                foreach (var identityError in result.Errors)
                {
                    errors.Add(new ExecutionError { Description = identityError.Description });
                }
                return ExecutionResult.Failed(errors.ToArray());
            }
            return ExecutionResult.Success;
        }

        public async Task<bool> Autenticate(string email, string password)
        {
            ArgumentException.ThrowIfNullOrEmpty(email);
            ArgumentException.ThrowIfNullOrEmpty(password);
            
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null) return false;
            return await _userManager.CheckPasswordAsync(appUser, password);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            ArgumentException.ThrowIfNullOrEmpty(email);
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser != null)
            {
                return await _userRepository.GeyByIdAsync(appUser.UserId);
            }
            return null;
        }
    }
}
