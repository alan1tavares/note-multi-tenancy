using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Repository
{
    internal interface IRepository<E>
    {
        public Task<E> SaveAsync(E entity);
        public void Update(E entity);
        public E GetById(Guid id);
        public IEnumerable<E> GetAll();
        public void Delete(Guid id);
    }
}
