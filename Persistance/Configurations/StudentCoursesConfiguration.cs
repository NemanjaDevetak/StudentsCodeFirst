using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class StudentCoursesConfiguration : BaseConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> entity)
        {

            entity.Property(e => e.CourseId);

            entity.Property(e => e.Grade);

            entity.Property(e => e.StudentId);

            entity.HasOne(d => d.Course)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId);
        }
    }
}
