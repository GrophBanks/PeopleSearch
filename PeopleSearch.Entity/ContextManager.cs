using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Entity
{
    /// <summary>
    /// A generic method for getting and saving entities
    /// </summary>
    public class ContextManager : IContextManager, IDisposable
    {
        public DbContext dbContext { get; set; }

        public ContextManager()
        {
            dbContext = new PeopleSearchContext();
        }

        /// <summary>
        /// Returns the given entity T for the provided expression
        /// </summary>
        /// <typeparam name="T">Any entity that is part of the current context</typeparam>
        /// <param name="expression">The expression used to search for the entity</param>
        /// <returns></returns>
        public virtual T Get<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return dbContext.Set<T>().Where(expression).FirstOrDefault();
        }

        /// <summary>
        /// Returns a list of the given entity for the provided expression
        /// </summary>
        /// <typeparam name="T">Any entity that is part of the current context</typeparam>
        /// <param name="expression">The expression used to search for the entity</param>
        /// <returns></returns>
        public virtual List<T> GetList<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return dbContext.Set<T>().Where(expression).ToList() 
                ?? new List<T>();
        }

        /// <summary>
        /// Inserts or updates the given entity depending on if an epxression is provided to find the entity to update
        /// </summary>
        /// <typeparam name="T">The entity to insert/update</typeparam>
        /// <param name="expression">An expression to find the entity to update</param>
        /// <returns></returns>
        public virtual T Save<T>(T entity, Expression<Func<T,bool>> expression = null) where T: class
        {
            T savedEntity;

            if (expression != null)
            {
                savedEntity = dbContext.Set<T>().FirstOrDefault(expression);
                savedEntity = entity;
            }
            else
            {
                savedEntity = dbContext.Set<T>().Add(entity);
            }

            dbContext.SaveChanges();

            return savedEntity;
        }

        /// <summary>
        /// Inserts or updates the given entity depending on if an epxression is provided to find the entity to update
        /// </summary>
        /// <typeparam name="T">The entity to insert/update</typeparam>
        /// <param name="expression">An expression to find the entity to update</param>
        /// <returns></returns>
        public virtual async Task<T> SaveAsyn<T>(T entity, Expression<Func<T, bool>> expression = null) where T : class
        {
            T savedEntity;

            if (expression != null)
            {
                savedEntity = dbContext.Set<T>().FirstOrDefault(expression);
                savedEntity = entity;
            }
            else
            {
                savedEntity = dbContext.Set<T>().Add(entity);
            }

            await dbContext.SaveChangesAsync();

            return savedEntity;
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
