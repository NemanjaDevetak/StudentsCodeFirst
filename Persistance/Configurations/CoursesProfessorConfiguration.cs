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
    public class CoursesProfessorConfiguration : BaseConfiguration<CoursesProfessors>, IEntityTypeConfiguration<CoursesProfessors>
    {
        public override void Configure(EntityTypeBuilder<CoursesProfessors> entity)
        {
            base.Configure(entity);

            entity.Property(e => e.CourseId);

            entity.Property(e => e.ProfessorId);

            entity.HasOne(d => d.Course)
                .WithMany(p => p.CourseProfessor)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Professor)
                .WithMany(p => p.CourseProfessors)
                .HasForeignKey(d => d.ProfessorId);
        }
    }
}
