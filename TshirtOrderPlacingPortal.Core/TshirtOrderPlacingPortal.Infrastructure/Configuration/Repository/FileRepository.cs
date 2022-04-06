
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Data;



namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository
{
    public class FileRepository : GenericRepository<Files>, IFileRepository
    {
        public FileRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Files>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(FileRepository));
                return new List<Files>();
            }
        }
        public override async Task<bool> Upsert(Files entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  Files GetByFileName(string fileName)
        {
          return  dbSet.Where(x=>x.FileName== fileName).Select(x=>x).FirstOrDefault();
           
        }
    }
}
