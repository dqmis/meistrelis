using System;
using System.Collections.Generic;
using meistrelis.Models;
using Microsoft.EntityFrameworkCore;

namespace user.PostgreSQL
{
    public class MeistrelisContext : DbContext
    {
        public MeistrelisContext(DbContextOptions<MeistrelisContext> opt) : base(opt) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique(true);
            
            modelBuilder.Entity<Service>()
                .HasIndex(s => new { s.Title })
                .IsUnique(true);
        }
    }
}