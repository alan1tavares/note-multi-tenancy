﻿using Domain.Entities;
using Domain.UseCase.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Repository
{
    public interface IRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        public Task SaveChangesAsync();
        public Task<ExecutionResult> AddAsync(TEntity entity);
        public Task<ExecutionResult> UpdateAsync(TEntity entity);
        public Task<ExecutionResult> RemoveAsync(Guid id);
        public Task<TEntity?> GeyByIdAsync(Guid id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
