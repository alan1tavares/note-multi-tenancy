using Domain.Entities;
using Domain.UseCase.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Account
{
    public interface IAccount
    {
        public Task<ExecutionResult> CreateAsync(UserAccount userAccount);
        public Task<bool> Autenticate(string email, string password);
        public Task<User?> FindByEmailAsync(string email);
    }
}
