using CommonLibrary.Repository.Configurations;
using CommonLibrary.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Repository.DBContext
{
    public class ProjectManagementTrackerDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rights> Rights { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        //Comment for migration
        public ProjectManagementTrackerDBContext(IConfiguration configuration, DbContextOptions<ProjectManagementTrackerDBContext> options) : base(options)
        {
            _configuration = configuration;
        }

        //Un-Comment for migration
        //public ProjectManagementTrackerDBContext() : base()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:trackerappserver.database.windows.net,1433;Initial Catalog=ProjectManagementTracker;Persist Security Info=False;User ID=trackerappadmin;Password=nC7VZ3pP!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new RightsConfiguration());
        //    modelBuilder.ApplyConfiguration(new RoleConfiguration());
        //    modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}
    }
}
