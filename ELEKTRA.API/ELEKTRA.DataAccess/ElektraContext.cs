using ELEKTRA.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ELEKTRA.DataAccess
{
    public class ElektraContext : DbContext
    {
        public ElektraContext(DbContextOptions<ElektraContext> options)
            : base(options)
        {
        }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
