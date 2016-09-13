using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Save();
    }
}
