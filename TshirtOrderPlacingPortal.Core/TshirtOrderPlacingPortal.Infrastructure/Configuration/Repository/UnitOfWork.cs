
using Microsoft.Extensions.Logging;
using System;

using System.Threading.Tasks;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Data;

namespace TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public ITshirtRepository Tshirt { get; private set; }
        public IStyleRepository Style { get; private set; }
        public ISizeRepository Size { get; private set; }
        public IFileRepository Files { get; private set; }

        public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Tshirt = new TshirtRepository(context, _logger);
            Size = new SizeRepository(context, _logger);
            Style= new StyleRepository(context, _logger);
            Files=new FileRepository(context, _logger);
        }

        public async Task Complete()
        {
           _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
