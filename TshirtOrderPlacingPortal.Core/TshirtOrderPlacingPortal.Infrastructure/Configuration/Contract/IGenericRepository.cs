using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(T entity);
       
    }
}
