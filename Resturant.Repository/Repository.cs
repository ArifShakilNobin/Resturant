using Microsoft.EntityFrameworkCore;
using Resturant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext? _context;
        //private readonly DbSet<T>? entity;

        public Repository(ApplicationDbContext? context)
        {
            _context = context;
            //entity = _context?.Set<T>();
        }

        public void Add(T entity)
        {
            _context?.Set<T>().Add(entity);
            _context?.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context?.Set<T>().AddRange(entities);
        }

        //public bool Alreadyexist(string name)
        //{

        //    return _context.Set<T>().Any(c => c.productName == name);
        //}

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            //return _context.Set<T>().ToList();
            return _context.Set<T>().Distinct().ToList();

        }

        public T GetById(int id)
        {
            var result =  _context?.Set<T>().Find(id);
            return result;
        }

        public void Remove(T entity)
        {
            _context?.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            var result = _context?.Set<T>().FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context?.Set<T>().Remove(result);
            }
            _context?.SaveChanges();

            //var result = await _context.Set<T>()
            //.FirstOrDefaultAsync(e => e.Id == id);
            //if (result != null)
            //{
            //    _context.Set<T>().Remove(result);
            //    await _context.SaveChangesAsync();
            //    return result;
            //}

            //return null;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context?.Set<T>().RemoveRange(entities);
        }

        //public void Update(T entity)
        //{
        //    _context?.Set<T>().Update(entity);
        //    _context?.SaveChanges();
        //}
    }
}
