using Domain.Entities;
using Domain.UseCase.Repository;
using Domain.UseCase.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class Repository<TEntity> : ICoreRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        private NoteDbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(NoteDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<ExecutionResult> AddAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _dbSet.AddAsync(entity);
            return ExecutionResult.Success;
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await Task.FromResult(query.ToList());
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet);
        }

        public async Task<TEntity?> GeyByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<ExecutionResult> RemoveAsync(Guid id)
        {
            var entity = await GeyByIdAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
            return ExecutionResult.Success;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task<ExecutionResult> UpdateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(ExecutionResult.Success);
        }
    }
}
