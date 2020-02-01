
using Microsoft.EntityFrameworkCore;
using SulsApp.Models;

namespace SulsApp
{ 
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-ASHPL84\SQLEXPRESS;Database=SULS;Integrated Security=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; } 
        public DbSet<Problem> Problems { get; set; } 
        public DbSet<Submission> Submissions  { get; set; }



    }
}
 