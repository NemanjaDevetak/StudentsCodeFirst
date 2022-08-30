﻿using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<GetStudentDto>> GetStudents(int page, int pageSize, int? courseId);
        Task<GetStudentDto> GetStudent(int id);
        Task<GetStudentDto> GetStudent(string firstName);
        Task UpdateStudent(UpdateStudentDto student);
        Task AddStudent(InsertStudentDto student);
        Task DeleteStudent(int id);
    }
}
