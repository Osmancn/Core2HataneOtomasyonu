using HastaneOtomasyonu.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HastaneOtomasyonu.DataAccess.Concreat.Entityframework
{
    public class GenericRepository<T, TContext> : IGenericRepository<T>
        where T : class
        where TContext : HastaneOtomasyonuDbContext, new()
    {
        public void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var context = new TContext();

            //var query = context.Set<T>()
            //    .Include(context.GetIncludePaths(typeof(T)));
            //if (filter != null)
            //    query = query.Where(filter);
            //return query;

            return filter == null
                         ? context.Set<T>()
                         : context.Set<T>().Where(filter);

        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<T>().FirstOrDefault() : context.Set<T>().FirstOrDefault(filter);
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}
