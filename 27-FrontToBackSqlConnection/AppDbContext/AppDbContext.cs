using _27_FrontToBackSqlConnection.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
    }
}