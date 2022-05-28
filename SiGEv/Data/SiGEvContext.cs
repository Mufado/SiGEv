using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
