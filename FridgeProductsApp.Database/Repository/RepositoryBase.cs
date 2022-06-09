using FridgeProductsApp.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Database.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FridgeProductsDbContext FridgeProductsDbContext;
        
        public RepositoryBase(FridgeProductsDbContext fridgeProductsDbContext)
        {
            FridgeProductsDbContext = fridgeProductsDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            FridgeProductsDbContext.Set<T>()
            .AsNoTracking() :
            FridgeProductsDbContext.Set<T>();

        IQueryable<T> IRepositoryBase<T>.FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            FridgeProductsDbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            FridgeProductsDbContext.Set<T>()
            .Where(expression);

        public void Create(T entity) => FridgeProductsDbContext.Set<T>().Add(entity);

        public void Update(T entity) => FridgeProductsDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => FridgeProductsDbContext.Set<T>().Remove(entity);
    }
}
