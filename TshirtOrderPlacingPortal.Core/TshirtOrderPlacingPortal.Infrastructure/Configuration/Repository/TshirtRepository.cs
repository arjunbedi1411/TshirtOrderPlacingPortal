
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
    public class TshirtRepository : GenericRepository<TShirt>, ITshirtRepository
    {
        public TshirtRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<TShirt>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TshirtRepository));
                return new List<TShirt>();
            }
        }
        public override async Task<bool> Upsert(TShirt entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.Size_Id = entity.Size_Id;
                existingUser.Style_Id = entity.Style_Id;
                existingUser.Manufature_Region = entity.Manufature_Region;
                existingUser.Gender = entity.Gender;
                existingUser.Cost = entity.Cost;
                existingUser.Description = entity.Description;
                existingUser.Colour = entity.Colour;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(TshirtRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(long id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(TshirtRepository));
                return false;
            }
        }
    }
}
