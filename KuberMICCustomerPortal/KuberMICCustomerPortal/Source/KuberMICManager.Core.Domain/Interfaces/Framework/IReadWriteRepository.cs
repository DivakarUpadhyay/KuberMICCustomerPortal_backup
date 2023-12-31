﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadWriteRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        // Add
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        // Remove     
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        // update     
        Task UpdateAsync(TEntity entity);
    }
}