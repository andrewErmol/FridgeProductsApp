using FridgeProductsApp.Contracts.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FridgeProductsApp.Database.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FridgeProductsDbContext FridgeProductsDbContext;
        
        public RepositoryBase(FridgeProductsDbContext fridgeProductsDbContext)
        {
            FridgeProductsDbContext = fridgeProductsDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ?
            FridgeProductsDbContext.Set<T>()
            .AsNoTracking() :
            FridgeProductsDbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
            FridgeProductsDbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            FridgeProductsDbContext.Set<T>()
            .Where(expression);
        }

        public void Create(T entity) => FridgeProductsDbContext.Set<T>().Add(entity);

        public void Update(T entity) => FridgeProductsDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => FridgeProductsDbContext.Set<T>().Remove(entity);
        
        public object ExecuteScalar(string sqlQuery, SqlParameter param)
        {
            FridgeProductsDbContext.Database.ExecuteSqlRaw(sqlQuery, param);
            return param.Value;
        }
    }
}
