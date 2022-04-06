
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
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Size>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(SizeRepository));
                return new List<Size>();
            }
        }
        public override async Task<bool> Upsert(Size entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
