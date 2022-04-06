using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration;

namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract
{
    public interface IFileRepository : IGenericRepository<Files>
    {
        Files GetByFileName(string fileName);
    }
}
