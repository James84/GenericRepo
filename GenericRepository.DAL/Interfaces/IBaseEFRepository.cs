using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepository.DAL.Interfaces
{
    internal interface IBaseEFRepository <TEntity> where TEntity : class
    {
        int Insert(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(int id);
    }
}
