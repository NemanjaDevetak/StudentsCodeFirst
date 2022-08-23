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
    public class CoursesProfessorConfiguration : BaseConfiguration<CoursesProfessors>
    {
        public void Configure(EntityTypeBuilder<CoursesProfessors> entity)
        {

            entity.Property(e => e.CourseId);

            entity.Property(e => e.ProfessorId);

            entity.HasOne(d => d.Course)
                .WithMany(p => p.CourseProfessor)
                .HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Professor)
                .WithMany(p => p.CourseProfessors)
                .HasForeignKey(d => d.ProfessorId);
        }
    }
}
