using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter); // Tek bir nesne listeleme, detaylarına inme
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Tüm nesne listesini döndürme
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
