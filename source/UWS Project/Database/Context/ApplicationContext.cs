using Microsoft.EntityFrameworkCore;
using UWS_Project.Model;

namespace UWS_Project.Database.Context
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Word> Words { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Unique_Word_Statistics;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasOne(p => p.Page)
                .WithMany(b => b.Words);
        }
    }
}