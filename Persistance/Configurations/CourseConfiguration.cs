using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CourseConfiguration : BaseConfiguration<Course>, IEntityTypeConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> entity)
        {
            base.Configure(entity);

            entity.HasIndex(e => e.Code)
                .IsUnique();

            entity.Property(e => e.Code).IsRequired().HasMaxLength(64);

            entity.Property(e => e.CourseName).IsRequired().HasMaxLength(64);

            entity.Property(e => e.DepartmentId).IsRequired(false);

            entity
            .HasOne(d => d.Department)
            .WithMany(p => p.Courses)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
