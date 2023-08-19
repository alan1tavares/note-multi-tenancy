using Domain.Entities;
using Domain.UseCase.Repository;
using Domain.UseCase.Result;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public UserRepository(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<NoteResult> SaveAsync(User entity)
        {
            var errors = new List<NoteError>();
            var user = new IdentityUser<Guid> 
            { 
                UserName = entity.Name,
                Email = entity.Email
            };

            var result = await _userManager.CreateAsync(user, entity.Password);
            if (!result.Succeeded)
            {
                foreach (var identityError in result.Errors)
                {
                    errors.Add(new NoteError { Description = identityError.Description });
                }
                return NoteResult.Failed(errors.ToArray());
            }
            return NoteResult.Success;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
