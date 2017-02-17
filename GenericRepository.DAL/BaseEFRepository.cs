using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using GenericRepository.DAL.Interfaces;

namespace GenericRepository.DAL
{
    public abstract class BaseEFRepository<TEntity, TContext> : IBaseEFRepository<TEntity> 
                                                                where TEntity : class 
                                                                where TContext : DbContext, new ()
    {
        public int Insert(TEntity entity)
        {
            using (var context = GetContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

                return 0;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = GetContext())
            {
                return context.Set<TEntity>().SingleOrDefault(predicate);
            }
        }

        public ICollection<TEntity> GetAll()
        {
            using (var context = GetContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = GetContext())
            {
                context.Set<TEntity>().AddOrUpdate(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = GetContext())
            {
                var entity = context.Set<TEntity>().Find(id);

                if (entity != null)
                {
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        private TContext GetContext()
        {
            return new TContext();
        }
    }
}
