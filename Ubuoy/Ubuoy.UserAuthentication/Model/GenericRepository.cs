using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;

namespace Ubuoy.UserAuthentication.Model
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ObjectContext _context;
        private IObjectSet<T> _objectSet;

        public GenericRepository()
            : this(new Model.Ubuoy_DB_ModelEntities())
        {

        }


        public GenericRepository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }


        public IQueryable<T> Fetch()
        {
            return _objectSet;
        }

        
        public IEnumerable<T> GetAll()
        {
            //return GetQuery().AsEnumerable(); 
            return null;
        }

        //lambda expressions
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _objectSet.Where<T>(predicate);
        }

       
        public T Single(Func<T, bool> predicate)
        {
            try
            {
                return _objectSet.Single<T>(predicate);
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
           
        }

        
        public T First(Func<T, bool> predicate)
        {
            return _objectSet.First<T>(predicate);
        }

       
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.DeleteObject(entity);
        }

       
        public void Delete(Func<T, bool> predicate)
        {
            IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;
            foreach (T record in records)
            {
                _objectSet.DeleteObject(record);
            }
        }

       
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.AddObject(entity);
        }

       
        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }

   
}
