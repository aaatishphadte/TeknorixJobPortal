using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using TeknorixAPI.Models;

namespace TeknorixAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging
            optionsBuilder.EnableSensitiveDataLogging();


        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
