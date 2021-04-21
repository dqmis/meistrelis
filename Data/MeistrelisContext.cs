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
        public DbSet<UserService> UserServices { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique(true);
            
            modelBuilder.Entity<Service>()
                .HasIndex(s => new { s.Title })
                .IsUnique(true);
            
            modelBuilder.Entity<UserService>()
                .HasKey(bc => new { bc.UserId, bc.ServiceId });  
            modelBuilder.Entity<UserService>()
                .HasOne(bc => bc.Service)
                .WithMany(b => b.UserServices)
                .HasForeignKey(bc => bc.ServiceId);  
            modelBuilder.Entity<UserService>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserServices)
                .HasForeignKey(bc => bc.UserId);
        }
    }
}