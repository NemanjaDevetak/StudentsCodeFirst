﻿using Application.Service.Dtos;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Course, GetCourseDto>().ReverseMap();
            CreateMap<Course, InsertCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
            CreateMap<Department, GetDepartmentDto>().ReverseMap();
            CreateMap<Department, InsertDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Professor, GetProfessorDto>().ReverseMap();
            CreateMap<Professor, InsertProfessorDto>().ReverseMap();
            CreateMap<Professor, UpdateProfessorDto>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, InsertStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<AddressDto, Address>()
                .ForCtorParam("country", opt => opt.MapFrom(src => src.Country))
                .ForCtorParam("city", opt => opt.MapFrom(src => src.City))
                .ForCtorParam("street", opt => opt.MapFrom(src => src.Street))
                .ForCtorParam("zipcode", opt => opt.MapFrom(src => src.ZipCode));
        }
    }
}
