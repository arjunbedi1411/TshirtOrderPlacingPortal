using Microsoft.EntityFrameworkCore;
using TshirtOrderPlacingPortal.DTO.Models;

namespace TshirtOrderPlacingPortal.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public virtual DbSet<TShirt> Tshirt { get; set; }
        public virtual DbSet<Style> Style { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
