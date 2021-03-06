using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.Infrastructure.Configuration;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Data;

namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DBContext context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DBContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;

        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }


        public virtual  async Task<bool> Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add function error", typeof(TshirtRepository));
                return false;
            }
        }


        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }


        public virtual  async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(TshirtRepository));
                return false;
            }
        }


        public virtual async Task<bool> Upsert(T entity)
        {
            try
            {
                dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(TshirtRepository));
                return false;
            }
        }
    }
}
