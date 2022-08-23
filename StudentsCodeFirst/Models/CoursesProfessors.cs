using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class CoursesProfessors : BaseEntity
    {
        public int? ProfessorId { get; set; }
        public int? CourseId { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Course Course { get; set; }
    }
}
