using Domain.Entities;
using Domain.UseCase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(NoteDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistAsync(Guid userId, Guid groupId)
        {
            var listGroupUser = await Get(e => (e.GroupId == groupId) && (e.UserId == userId));
            return listGroupUser.Count() > 0;
        }
    }
}
