using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
        {            
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursesProfessors> CoursesProfessors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0N88TA5;Database=Task02;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
        }
    }
}
