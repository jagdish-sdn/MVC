using SDHP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Repository
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();

        IQueryable<T> Get(Expression<Func<T, bool>> expression, ref string errorMessage);
        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        //T GetSingle(long id);
        T GetSingle(long id, ref string errorMessage);

        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, ref string errorMessage);

        //void Add(T entity);
        void Add(T entity, ref string errorMessage);

        //void Delete(T entity);
        void Delete(T entity, ref string errorMessage);

        //void Update(T oldEntity, T newEntity);
        void Update(T oldEntity, T newEntity, ref string errorMessage);

        //void AddRange(IEnumerable<T> entities);
        void AddRange(IEnumerable<T> entities, ref string errorMessage);

        //void SoftDelete(T entity);
        void SoftDelete(T entity, ref string errorMessage);

    }
}
