using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Repository
{
    public interface IGroupUserRepository : ICoreRepositoryAsync<GroupUser>
    {
        public Task<bool> ExistAsync(Guid userId, Guid groupId);
    }
}
