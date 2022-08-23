﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class StudentCourses : BaseEntity
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int Grade { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}