using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductContext _context = null;
        private bool disposed = false;

        public Repository(ProductContext context)
        {
            _context = new ProductContext();
        }

        public Repository()
        {
            _context = new ProductContext();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;            
        }


        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Save()
        {
            //try
            //{
                _context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
