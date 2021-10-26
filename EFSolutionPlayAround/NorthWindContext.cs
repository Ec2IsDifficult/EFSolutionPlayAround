using System;
using EFSolutionPlayAround.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSolutionPlayAround
{
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=Pedal14");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //These are dependencies, but they are limited to only exist here.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");
        }
    }
}