using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiGEv.Models;

namespace SiGEv.Data
{
    public class SiGEvContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public SiGEvContext(DbContextOptions<SiGEvContext> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
