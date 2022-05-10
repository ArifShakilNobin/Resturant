﻿using Resturant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Repository
{
    public interface IRepository <T> where T : BaseEntity
    {
        //IEnumerable<T> GetAll();
        //T GetProductById(Guid id);


        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Delete(int id);

        //void Update(T entity);


        //bool Alreadyexist(string name);


        IQueryable<T> FindAll();

    }
}
