using SDHP.Entities;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {

        private ApplicationContext dataContext;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ApplicationContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().Where(x => (x.DeletionDate == null));
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> expression, ref string errorMessage)
        {
            try
            {
                return expression != null ? DbContext.Set<T>().Where(expression) : DbContext.Set<T>();
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
                return null;
            }
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                return DbContext.Set<T>().Where(expression);
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>().Where(x => x.DeletionDate == null);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        /// <summary>
        /// Method to get the single entity in id gets matched.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        /// <returns></returns>
        public T GetSingle(long id, ref string errorMessage)
        {
            try
            {
                return GetAll().FirstOrDefault(x => x.ID == id);
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
                return null;
            }
        }
        /// <summary>
        /// Method to find the given entity.
        /// </summary>
        /// <param name="predicate">Provide the search entity.</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        /// <returns></returns>
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate, ref string errorMessage)
        {
            try
            {
                return DbContext.Set<T>().Where(predicate).Where(x => x.DeletionDate == null);
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
                return null;
            }
        }
        /// <summary>
        /// Method to add the entity into the collection.
        /// </summary>
        /// <param name="entity">Entity that will insert into the collection.</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        public virtual void Add(T entity, ref string errorMessage)
        {
            try
            {
                T t = new T();

                //entity.IsDeleted = false;

                //DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                DbContext.Entry<T>(entity);
                t = DbContext.Set<T>().Add(entity);
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
            }
        }
        /// <summary>
        /// Method to add the entity range into the collection.
        /// </summary>
        /// <param name="entities">Entity collection</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        public virtual void AddRange(IEnumerable<T> entities, ref string errorMessage)
        {
            try
            {
                foreach (var entity in entities)
                {
                    //entity.IsDeleted = false;
                    DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                    DbContext.Set<T>().Add(entity);
                }
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
            }
        }
        /// <summary>
        /// Method to update/replace the entity.
        /// </summary>
        /// <param name="oldEntity">Old entity that will be updated with new one. </param>
        /// <param name="newEntity">New entity that will change the old record.</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        public virtual void Update(T oldEntity, T newEntity, ref string errorMessage)
        {
            try
            {

                DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
            }
        }
        /// <summary>
        /// Method is use to delete the entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        /// <param name="errorMessage">Catch the exception message on execution.</param>
        public virtual void Delete(T entity, ref string errorMessage)
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
            }
        }
        /// <summary>
        /// Method is use to change the flag that record has been deleted but will be exist.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMessage"></param>
        public virtual void SoftDelete(T entity, ref string errorMessage)
        {
            try
            {
                //entity.IsDeleted = true;
                //entity.DeletedOn = DateTime.UtcNow;

                DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified;
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
            }
        }
    }
}
