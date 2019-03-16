using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Entity
{
    public interface IContextManager
    {
        T Get<T>(Expression<Func<T, bool>> expression) where T : class;

        List<T> GetList<T>(Expression<Func<T, bool>> expression) where T : class;

        T Save<T>(T entity, Expression<Func<T, bool>> expression = null) where T : class;

        void Dispose();
    }
}
