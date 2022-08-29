using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using AutoMapper;
using Domain.Models;
using Infrastructure.Domain;

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperService());
});



IMapper mapper = config.CreateMapper();

ICourseService courseService = new CourseService(mapper);
StudentDto studentDto = new();
CourseDto courseDto = new();

studentDto.Id = 3;
courseDto.Id = 9;

await courseService.AddStudent(courseDto, studentDto);