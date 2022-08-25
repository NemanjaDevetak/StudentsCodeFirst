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
    public class ProfessorConfiguration : BaseConfiguration<Professor>, IEntityTypeConfiguration<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> entity)
        {
            base.Configure(entity);

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(64); ;

            entity.Property(e => e.LastName).IsRequired().HasMaxLength(64); ;

            entity
                .OwnsOne(e => e.Address, sb =>
            {
                sb.Property(x => x.Country).HasDefaultValue(string.Empty);
                sb.Property(x => x.City).HasDefaultValue(string.Empty);
                sb.Property(x => x.ZipCode).HasDefaultValue(string.Empty);
                sb.Property(x => x.Street).HasDefaultValue(string.Empty);
            });
        }
    }
}
