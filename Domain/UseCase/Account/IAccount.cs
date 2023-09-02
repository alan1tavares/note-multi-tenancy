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
    }
}
