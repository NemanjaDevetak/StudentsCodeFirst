using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using AutoMapper;
using Domain.Models;
using Infrastructure.Domain;
using System.Collections.Generic;

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperService());
});



IMapper mapper = config.CreateMapper();

IStudentService studentService = new StudentService(mapper);

IEnumerable<GetStudentDto> students;

students = await studentService.GetStudents(1, 5, null, "Ana", null);

foreach (var student in students) {
    Console.WriteLine(student.LastName);
}