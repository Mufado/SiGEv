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
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
