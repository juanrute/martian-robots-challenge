using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class MisionDbContext : DbContext
    {
        private string DbConnection { get; }
        public MisionDbContext(DbContextOptions<MisionDbContext> options, IConfiguration configuration)
            : base(options)
        {
            DbConnection = configuration.GetConnectionString("MisionDb");
        }
        public DbSet<MisionModel> Mision { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite(DbConnection);
    }
}
