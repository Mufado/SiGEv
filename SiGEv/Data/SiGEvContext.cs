using Microsoft.EntityFrameworkCore;
using SiGEv.Models;

namespace SiGEv.Data
{
    public class SiGEvContext : DbContext
    {
        public SiGEvContext(DbContextOptions<SiGEvContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
