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
    public class CourseConfiguration : BaseConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.HasIndex(e => e.Code)
                .IsUnique();

            entity.Property(e => e.Code);

            entity.Property(e => e.CourseName);

            entity.Property(e => e.DepartmentId);

            entity
            .HasOne(d => d.Department)
            .WithMany(p => p.Courses)
            .HasForeignKey(d => d.DepartmentId);
        }
    }
}
