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
    public class StudentConfiguration : BaseConfiguration<Student>, IEntityTypeConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> entity)
        {
            base.Configure(entity);

            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(64);

            entity.Property(e => e.LastName).IsRequired().HasMaxLength(64);

            entity.Property(e => e.StudentIndex).HasMaxLength(64);

            entity
                .OwnsOne(e => e.Address, sb =>
            {
                sb.Property(x => x.Country).IsRequired().HasMaxLength(64);
                sb.Property(x => x.City).IsRequired().HasMaxLength(64);
                sb.Property(x => x.ZipCode).IsRequired().HasMaxLength(64);
                sb.Property(x => x.Street).IsRequired().HasMaxLength(64);
            });
        }
    }
}
