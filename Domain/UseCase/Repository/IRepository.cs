using Domain.UseCase.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Repository
{
    public interface IRepository<E>
    {
        public Task<NoteResult> SaveAsync(E entity);
        public void Update(E entity);
        public E GetById(Guid id);
        public IEnumerable<E> GetAll();
        public void Delete(Guid id);
    }
}
