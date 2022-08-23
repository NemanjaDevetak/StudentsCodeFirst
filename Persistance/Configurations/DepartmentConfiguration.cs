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
    public class DepartmentConfiguration : BaseConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.Property(e => e.DeptartmentName);
        }
    }
}
