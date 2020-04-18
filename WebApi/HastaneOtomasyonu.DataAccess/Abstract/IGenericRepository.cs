using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HastaneOtomasyonu.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
