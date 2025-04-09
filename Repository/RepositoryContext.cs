using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repository
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskPriority> TaskPriorities { get; set; }
        public DbSet<EmailVerifications> EmailVerifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Not Started" },
                new Status { Id = 2, Name = "In Progress" },
                new Status { Id = 3, Name = "Completed" }
            );

            modelBuilder.Entity<TaskPriority>().HasData(
                new TaskPriority { Id = 1, Name = "Low" },
                new TaskPriority { Id = 2, Name = "Medium" },
                new TaskPriority { Id = 3, Name = "High" }
            );

            modelBuilder.Entity<TaskCategory>().HasData(
                new TaskCategory { Id = 1, Name = "Daily" },
                new TaskCategory { Id = 2, Name = "Weekly" },
                new TaskCategory { Id = 3, Name = "Yearly" }
            );
        }

    }
}
