using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Players> players { get; set; }
        public DbSet<Rank> rank { get; set; }
        public DbSet<Achievements> achievement {get;set;}
        public DbSet<Skins> skins { get; set; }
        public DbSet<SkinsPlayer> skinsPlayer { get; set; }
    }
}
