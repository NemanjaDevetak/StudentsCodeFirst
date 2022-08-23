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
    public class ProfessorConfiguration : BaseConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> entity)
        {

            entity.Property(e => e.City);

            entity.Property(e => e.Country);

            entity.Property(e => e.FirstName);

            entity.Property(e => e.LastName);

            entity.Property(e => e.Street);

            entity.Property(e => e.ZipCode);
        }
    }
}
