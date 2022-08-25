﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        void AddCourse(Course course);
    }
}